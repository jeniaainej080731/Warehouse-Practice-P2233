using AutoMapper;
using System.Transactions;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly ProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(ProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await productRepository.GetAllProductsAsync();
            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdWithCategoryAsync(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> AddAsync(ProductDto productDto)
        {
            var categoryId = await productRepository.GetCategoryIdByNameAsync(productDto.CategoryName);
            if (categoryId == null)
                throw new ArgumentException($"Category '{productDto.CategoryName}' not found.");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var product = mapper.Map<Product>(productDto);
                product.CategoryId = categoryId.Value;

                await productRepository.AddAsync(product);

                scope.Complete();

                return mapper.Map<ProductDto>(product);
            }
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = await productRepository.GetByIdAsync(productDto.ProductId);
            if (product == null)
                throw new ArgumentException($"Product with ID '{productDto.ProductId}' not found.");

            mapper.Map(productDto, product);

            var categoryId = await productRepository.GetCategoryIdByNameAsync(productDto.CategoryName);
            if (categoryId == null)
                throw new ArgumentException($"Category '{productDto.CategoryName}' not found.");

            product.CategoryId = categoryId.Value;

            await productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null)
                throw new ArgumentException($"Product with ID '{id}' not found.");

            await productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetBySupplierAsync(int selectedSupplier)
        {
            if (selectedSupplier == null)
                throw new ArgumentNullException(nameof(selectedSupplier));

            var products = await productRepository.GetBySupplierAsync(selectedSupplier);
            if (products == null || !products.Any())
                return Enumerable.Empty<ProductDto>();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
