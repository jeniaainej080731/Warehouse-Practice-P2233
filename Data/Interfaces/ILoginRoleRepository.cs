using Warehouse.Data.DTO;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface ILoginRoleRepository
    {
        Task<IEnumerable<LoginRoleDto>> GetAllAsync();
        Task<LoginRoleDto> GetByIdAsync(int id);
        Task AddAsync(LoginRoleDto loginRoleDto);
        Task UpdateAsync(LoginRoleDto loginRoleDto);
        Task DeleteAsync(int id);
        Task<LoginRole> GetByCredentialsAsync(string login, string password);
        Task<LoginRole> GetByEmployeeIdAsync(int employeeId);
    }
}
