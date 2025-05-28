using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface IOperationService
    {
        Task<IEnumerable<OperationDto>> GetAllAsync();
        Task<IEnumerable<OperationDto>> GetAllWithDetailsAsync();
        Task<OperationDto> GetByIdAsync(int id);
        Task<OperationDto> GetByProductIdAsync(int productId);
        Task AddAsync(OperationDto operation);
        Task UpdateAsync(OperationDto operation);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
