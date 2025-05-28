using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface IReceiptRepository : IRepository<Receipt>
    {
        Task<IEnumerable<Receipt>> GetByEmployeeIdAsync(int employeeId);
        Task<Receipt> GetByIdWithDetailsAsync(int id);
        Task<Receipt> AddReceiptWithTransactionAsync(Receipt receipt);
        Task<bool> UpdateReceiptWithTransactionAsync(Receipt receipt);
        Task<bool> DeleteReceiptWithTransactionAsync(int id);
        Task<bool> ReceiptExistsAsync(int id);
        Task<bool> ReceiptExistsByEmployeeIdAsync(int employeeId);
    }
}
