using Warehouse.Data.DTO;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface IDeletedProductRepository : IRepository<DeletedProduct>
    {
        Task<DeletedProductsDto> GetByProductId(int productId);
    }
}
