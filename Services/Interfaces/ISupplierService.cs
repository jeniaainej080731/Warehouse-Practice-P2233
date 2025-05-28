using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto> GetByIdAsync(int id);
        Task<SupplierDto> AddAsync(SupplierDto supplierDto);
        Task UpdateAsync(SupplierDto supplierDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<SupplierDto>> GetByNameAsync(string name);
    }
}
