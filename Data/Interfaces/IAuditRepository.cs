using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface IAuditRepository
    {
        Task<IEnumerable<Audit>> GetAllAsync();
        Task<IEnumerable<Audit>> GetAllWithProductsAndEmployeeAsync();
        Task<Audit> GetByIdAsync(int id);

        // Запись/обновление/удаление только сущности Audit
        Task AddAsync(Audit audit);
        Task UpdateAsync(Audit audit);
        Task DeleteAsync(int id);

        Task<bool> ExistsAsync(int id);
    }
}
