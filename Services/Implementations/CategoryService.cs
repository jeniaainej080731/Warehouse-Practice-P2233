using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task AddAsync(CategoryDto dto)
        {
            var category = mapper.Map<Category>(dto);
            await categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var category = await categoryRepository.GetByIdAsync(dto.CategoryId)
                ?? throw new ArgumentException($"Category with ID '{dto.CategoryId}' not found.");

            mapper.Map(dto, category);
            await categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await categoryRepository.ExistsAsync(id);
            if (!exists)
                throw new ArgumentException($"Category with ID '{id}' not found.");

            await categoryRepository.DeleteAsync(id);
        }

        public async Task<string> GetDescriptionById(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new ArgumentException($"Category with ID '{id}' not found.");
            return category.CategoryDescription;
        }
    }

}
