using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface IReceiptService
    {
        Task<IEnumerable<ReceiptDto>> GetAllAsync();
        Task<ReceiptDto> GetByIdAsync(int id);
        Task<ReceiptDto> AddAsync(ReceiptDto receiptDto);
        Task UpdateAsync(ReceiptDto receiptDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ReceiptDto>> GetByEmployeeIdAsync(int employeeId);
        Task<bool> ReceiptExistsAsync(int id);
        Task<bool> ReceiptExistsByEmployeeIdAsync(int employeeId);
    }
}
