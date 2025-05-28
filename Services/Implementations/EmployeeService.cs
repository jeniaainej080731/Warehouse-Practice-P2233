using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper;
        }

        public Task<IEnumerable<EmployeeDto>> GetAllAsync() =>
            _repo.GetAllWithRolesAsync();

        public Task<EmployeeDto> GetByIdAsync(int id) =>
            _repo.GetByIdWithRoleAsync(id);

        public Task AddAsync(EmployeeDto dto) =>
            _repo.AddAsync(_mapper.Map<Employee>(dto));

        public Task UpdateAsync(EmployeeDto dto) =>
            _repo.UpdateAsync(_mapper.Map<Employee>(dto));

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
