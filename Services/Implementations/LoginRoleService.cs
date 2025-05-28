using Warehouse.Data.DTO;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class LoginRoleService : ILoginRoleService
    {
        private readonly ILoginRoleRepository repository;

        public LoginRoleService(ILoginRoleRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<LoginRoleDto>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<LoginRoleDto> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task AddAsync(LoginRoleDto loginRoleDto)
        {
            if (loginRoleDto == null)
                throw new ArgumentNullException(nameof(loginRoleDto));
            await repository.AddAsync(loginRoleDto);
        }

        public async Task<LoginRoleDto> GetByCredentials(string userLogin, string userPassword)
        {
            var entity = await repository.GetByCredentialsAsync(userLogin, userPassword);
            if (entity == null)
                throw new UnauthorizedAccessException("Invalid login or password.");

            return new LoginRoleDto
            {
                LoginId = entity.LoginId,
                Login = entity.Login,
                Password = entity.Password,
                Role = entity.Role
            };
        }

        public async Task<bool> IsAdmin(int employeeId)
        {
            var loginRole = await repository.GetByEmployeeIdAsync(employeeId);
            return loginRole != null && loginRole.Role.ToLower().Equals("admin");
        }
    }
}
