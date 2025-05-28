using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface IAuditService
    {
        Task<IEnumerable<AuditDto>> GetAllAsync();
        Task<AuditDto> GetByIdAsync(int id);
        Task AddAsync(AuditDto auditDto);
        Task UpdateAsync(AuditDto auditDto);
        Task DeleteAsync(int id);
    }
}
