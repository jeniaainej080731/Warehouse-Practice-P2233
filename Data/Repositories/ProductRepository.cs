using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class ProductRepository : Repository<Product, MasterDbContext>, IProductRepository
    {
        private readonly MasterDbContext context;
        private readonly AuditDbContext auditDbContext;

        public ProductRepository(MasterDbContext context, AuditDbContext auditDbContext)
            : base(context)
        {
            this.context = context;
            this.auditDbContext = auditDbContext;
        }

        public async Task<Product> AddProductWithTransactionAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await dbSet.Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId)
        {
            return await dbSet
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithCategoryAsync(int id)
        {
            return await dbSet
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<int?> GetCategoryIdByNameAsync(string categoryName)
        {
            var category = await context.Categories
                .FirstOrDefaultAsync(c => c.CategoryName == categoryName);

            return category?.CategoryId;
        }

        public async Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId)
        {
            var productIds = await auditDbContext.Operations
                .AsNoTracking()
                .Where(o => o.SupplierId == supplierId)
                .Select(o => o.ProductId)
                .Distinct()
                .ToListAsync()
                .ConfigureAwait(false);

            Debug.WriteLine($"Found {productIds.Count} operations for supplier {supplierId}");

            if (productIds == null || !productIds.Any())
            {
                return Enumerable.Empty<Product>();
            }

            return await dbSet
                .Include(p => p.Category)
                .Where(p => productIds.Contains(p.ProductId))
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
