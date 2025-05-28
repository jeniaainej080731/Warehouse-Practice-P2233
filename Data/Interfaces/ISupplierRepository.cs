using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> GetByNameAsync(string name);
        Task<Supplier> GetByIdWithInvoicesAsync(int id);
        Task<Supplier> GetByIdWithOperationsAsync(int id);
        Task<Supplier> GetByIdWithInvoicesAndOperationsAsync(int id);
    }
}
