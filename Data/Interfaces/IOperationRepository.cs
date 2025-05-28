using Warehouse.Data.DTO;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    internal interface IOperationRepository : IRepository<Operation>
    {
        Task<IEnumerable<OperationDto>> GetAllWithDetails();
        Task<IEnumerable<OperationDto>> GetByProductIdAsync(int productId);
        Task<IEnumerable<Operation>> GetBySupplierIdAsync(int supplierId);
        Task<IEnumerable<Operation>> GetByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Operation>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Operation>> GetByTypeAsync(string operationType);
        Task AddOperationAsync(Operation operation);
    }
}
