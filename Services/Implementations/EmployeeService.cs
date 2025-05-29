using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            // Map DTO to Entity for both add and update
            CreateMap<EmployeeDto, Employee>()
                // Map all scalar fields including PK
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.PhotoPath))
                .ForMember(dest => dest.LoginId, opt => opt.MapFrom(src => src.LoginId))
                // Ignore navigation to prevent accidental FK entity changes
                .ForMember(dest => dest.LoginRole, opt => opt.Ignore());

            // Map Entity to DTO (for reads)
            CreateMap<Employee, EmployeeDto>();
        }
    }
}

namespace Warehouse.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<IEnumerable<EmployeeDto>> GetAllAsync() =>
            _repo.GetAllWithRolesAsync();

        public Task<EmployeeDto> GetByIdAsync(int id) =>
            _repo.GetByIdWithRoleAsync(id);

        public async Task AddAsync(EmployeeDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            // Ensure new PK
            dto.EmployeeId = 0;
            var entity = _mapper.Map<Employee>(dto);
            await _repo.AddAsync(entity);
        }

        public async Task UpdateAsync(EmployeeDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            // Map DTO to Entity (with existing PK)
            var entity = _mapper.Map<Employee>(dto);
            await _repo.UpdateAsync(entity);
        }

        public Task DeleteAsync(int id) =>
            _repo.DeleteAsync(id);

        public Task<bool> ExistsAsync(int id) =>
            _repo.ExistsAsync(id);

        public async Task<bool> IsAdminAsync(int loginId)
        {
            var dto = await _repo.GetByIdWithRoleAsync(loginId);
            return dto?.Role == "Admin";
        }
    }
}
