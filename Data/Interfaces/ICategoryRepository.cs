using Warehouse.Data.DTO;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task AddAsync(CategoryDto category);
        Task UpdateAsync(CategoryDto category);
        Task DeleteAsync(int id);
    }
}
