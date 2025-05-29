using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetByNameAsync(string name);
        Task<Employee> GetByIdWithInvoicesAsync(int id);
        Task<Employee> GetByIdWithOperationsAsync(int id);
        Task<Employee> GetByIdWithInvoicesAndOperationsAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetAllWithRolesAsync();
        Task<EmployeeDto> GetByIdWithRoleAsync(int id);
        Task<Employee> GetByIdEntityAsync(int id);
    }
}