using Warehouse.Data.DTO;

namespace Warehouse.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task AddAsync(CategoryDto categoryDto);
        Task UpdateAsync(CategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task<string> GetDescriptionById(int id);
    }
}
