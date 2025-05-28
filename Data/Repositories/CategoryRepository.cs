using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class CategoryRepository : Repository<Category, MasterDbContext>, ICategoryRepository
    {
        private readonly MasterDbContext context;

        public CategoryRepository(MasterDbContext context)
            : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return await context.Categories
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName
                })
                .ToListAsync();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return null;
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public async Task AddAsync(CategoryDto category)
        {
            var newCategory = new Category
            {
                CategoryName = category.CategoryName
            };
            await context.Categories.AddAsync(newCategory);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CategoryDto category)
        {
            var existingCategory = await context.Categories.FindAsync(category.CategoryId);
            if (existingCategory == null) return;
            existingCategory.CategoryName = category.CategoryName;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category == null) return;
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }

        // Fix for CS0738: Implement IRepository<Category>.GetAllAsync()
        async Task<IEnumerable<Category>> IRepository<Category>.GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        // Fix for CS0738: Implement IRepository<Category>.GetByIdAsync(int)
        async Task<Category> IRepository<Category>.GetByIdAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        // Fix for CS0535: Implement IRepository<Category>.AddAsync(Category)
        async Task IRepository<Category>.AddAsync(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        // Fix for CS0535: Implement IRepository<Category>.UpdateAsync(Category)
        async Task IRepository<Category>.UpdateAsync(Category category)
        {
            var existingCategory = await context.Categories.FindAsync(category.CategoryId);
            if (existingCategory == null) return;
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.CategoryDescription = category.CategoryDescription;
            await context.SaveChangesAsync();
        }

        // Fix for CS0535: Implement IRepository<Category>.ExistsAsync(int)
        async Task<bool> IRepository<Category>.ExistsAsync(int id)
        {
            return await context.Categories.AnyAsync(c => c.CategoryId == id);
        }
    }
}
