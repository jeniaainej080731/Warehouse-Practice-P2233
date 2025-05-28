using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class LoginRoleService : ILoginRoleService
    {
        private readonly ILoginRoleRepository repository;
        private readonly IMapper mapper;

        public LoginRoleService(ILoginRoleRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<LoginRoleDto>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<LoginRoleDto> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(LoginRoleDto loginRoleDto)
        {
            if (loginRoleDto == null)
                throw new ArgumentNullException(nameof(loginRoleDto));

            // Проверка существования логина
            bool loginExists = await repository.LoginExistsAsync(loginRoleDto.Login);
            if (loginExists)
            {
                throw new InvalidOperationException($"Login '{loginRoleDto.Login}' already exists");
            }

            var entity = mapper.Map<LoginRole>(loginRoleDto);
            await repository.AddAsync(entity);
            return entity.LoginId;
        }

        public async Task<LoginRoleDto> GetByCredentials(string userLogin, string userPassword)
        {
            var entity = await repository.GetByCredentialsAsync(userLogin, userPassword);
            if (entity == null)
                throw new UnauthorizedAccessException("Invalid login or password.");

            return mapper.Map<LoginRoleDto>(entity);
        }

        public async Task<bool> IsAdmin(int employeeId)
        {
            var loginRole = await repository.GetByEmployeeIdAsync(employeeId);
            return loginRole != null && loginRole.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }
    }
}