using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task AddAsync(EmployeeDto dto);
        Task UpdateAsync(EmployeeDto dto);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> IsAdminAsync(int loginId);
    }
}
