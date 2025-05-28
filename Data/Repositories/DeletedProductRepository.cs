using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class DeletedProductRepository : Repository<DeletedProduct, AuditDbContext>, IDeletedProductRepository
    {
        private readonly AuditDbContext auditDbContext;
        public DeletedProductRepository(AuditDbContext auditDbContext)
            : base(auditDbContext)
        {
            this.auditDbContext = auditDbContext;
        }

        public async Task<DeletedProductsDto> GetByProductId(int productId)
        {
            var deletedProduct = await dbSet
                .Where(d => d.ProductId == productId)
                .Select(d => new DeletedProductsDto
                {
                    ProductId = d.ProductId,
                    ProductName = d.ProductName,
                    ProductQuantity = d.ProductQuantity,
                    ProductPrice = d.ProductPrice,
                    ProductCode = d.ProductCode,
                    DateOfReceipt = d.DateOfReceipt,
                    CategoryId = d.CategoryId
                })
                .FirstOrDefaultAsync();

            return deletedProduct;
        }
    }
}
