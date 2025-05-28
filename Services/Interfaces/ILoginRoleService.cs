using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface ILoginRoleService
    {
        Task<IEnumerable<LoginRoleDto>> GetAllAsync();
        Task<LoginRoleDto> GetByCredentials(string userLogin, string userPassword);
        Task<LoginRoleDto> GetByIdAsync(int id);
        Task<bool> IsAdmin(int employeeId);
        Task<int> AddAsync(LoginRoleDto loginRoleDto);
    }
}
