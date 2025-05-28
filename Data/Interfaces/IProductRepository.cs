using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategoryAsync(int categoryId);
        Task<Product> GetByIdWithCategoryAsync(int id);
        Task<int?> GetCategoryIdByNameAsync(string categoryName);
        Task<Product> AddProductWithTransactionAsync(Product product);
        Task<IEnumerable<Product>> GetBySupplierAsync(int supplierId);
    }
}
