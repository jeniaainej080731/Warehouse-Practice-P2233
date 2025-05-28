using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class ReceiptRepository : Repository<Receipt, TransactionDbContext>, IReceiptRepository
    {
        private readonly TransactionDbContext transactionDbContext;
        private readonly MasterDbContext masterDbContext;

        public ReceiptRepository(TransactionDbContext context, MasterDbContext masterDbContext)
            : base(context)
        {
            transactionDbContext = context;
            this.masterDbContext = masterDbContext;
        }

        public async Task<IEnumerable<Receipt>> GetByEmployeeIdAsync(int employeeId)
        {
            return await transactionDbContext.Receipts
                .Where(r => r.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<Receipt> GetByIdWithDetailsAsync(int id)
        {
            // Load receipt and its details and employee
            var receipt = await transactionDbContext.Receipts
                .Include(r => r.ReceiptDetails)
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(r => r.ReceiptId == id);

            if (receipt != null && receipt.ReceiptDetails != null)
            {
                // Populate product details from masterDbContext for each detail
                foreach (var detail in receipt.ReceiptDetails)
                {
                    detail.Product = await masterDbContext.Products
                        .Include(p => p.Category)
                        .FirstOrDefaultAsync(p => p.ProductId == detail.ProductId);
                }
            }

            return receipt;
        }

        public async Task<Receipt> AddReceiptWithTransactionAsync(Receipt receipt)
        {
            using var transaction = await transactionDbContext.Database.BeginTransactionAsync();
            try
            {
                // 1. Add receipt in transaction context
                await transactionDbContext.Receipts.AddAsync(receipt);
                await transactionDbContext.SaveChangesAsync();

                // 2. Update product stock in master context
                if (receipt.ReceiptDetails != null && receipt.ReceiptDetails.Any())
                {
                    var totalQuantity = receipt.ReceiptDetails.Sum(d => d.QuantityInReceipt);
                    var productId = receipt.ReceiptDetails.First().ProductId;

                    var product = await masterDbContext.Products
                        .FirstOrDefaultAsync(p => p.ProductId == productId);

                    if (product != null)
                    {
                        product.ProductQuantity -= totalQuantity;
                        masterDbContext.Products.Update(product);
                        await masterDbContext.SaveChangesAsync();
                    }
                }

                await transaction.CommitAsync();
                return receipt;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UpdateReceiptWithTransactionAsync(Receipt receipt)
        {
            using var transaction = await transactionDbContext.Database.BeginTransactionAsync();
            try
            {
                transactionDbContext.Receipts.Update(receipt);
                await transactionDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteReceiptWithTransactionAsync(int id)
        {
            using var transaction = await transactionDbContext.Database.BeginTransactionAsync();
            try
            {
                var receipt = await transactionDbContext.Receipts
                    .Include(r => r.ReceiptDetails)
                    .FirstOrDefaultAsync(r => r.ReceiptId == id);
                if (receipt == null) return false;

                // Restore product stock before deletion
                if (receipt.ReceiptDetails != null && receipt.ReceiptDetails.Any())
                {
                    var totalQuantity = receipt.ReceiptDetails.Sum(d => d.QuantityInReceipt);
                    var productId = receipt.ReceiptDetails.First().ProductId;

                    var product = await masterDbContext.Products
                        .FirstOrDefaultAsync(p => p.ProductId == productId);

                    if (product != null)
                    {
                        product.ProductQuantity += totalQuantity;
                        masterDbContext.Products.Update(product);
                        await masterDbContext.SaveChangesAsync();
                    }
                }

                transactionDbContext.Receipts.Remove(receipt);
                await transactionDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> ReceiptExistsAsync(int id)
        {
            return await transactionDbContext.Receipts.AnyAsync(r => r.ReceiptId == id);
        }

        public async Task<bool> ReceiptExistsByEmployeeIdAsync(int employeeId)
        {
            return await transactionDbContext.Receipts.AnyAsync(r => r.EmployeeId == employeeId);
        }
    }
}
