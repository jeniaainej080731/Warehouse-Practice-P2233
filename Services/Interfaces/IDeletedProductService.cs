using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface IDeletedProductService
    {
        Task<DeletedProductsDto> GetByProductId(int productId);
        Task AddAsync(DeletedProductsDto deletedProduct);
        Task DeleteAsync(int id);
    }
}
