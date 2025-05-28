using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<ProductDto>> GetBySupplierAsync(int selectedSupplier);
    }
}
