using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class DeletedProductService : IDeletedProductService
    {
        private readonly IDeletedProductRepository deletedProductRepository;
        private readonly IMapper mapper;
        public DeletedProductService(IDeletedProductRepository deletedProductRepository, IMapper mapper)
        {
            this.deletedProductRepository = deletedProductRepository;
            this.mapper = mapper;
        }

        public async Task<DeletedProductsDto> GetByProductId(int productId)
        {
            var deletedProduct = await deletedProductRepository.GetByProductId(productId);
            if (deletedProduct == null)
            {
                return null;
            }
            return mapper.Map<DeletedProductsDto>(deletedProduct);
        }

        public async Task AddAsync(DeletedProductsDto deletedProduct)
        {
            var entity = mapper.Map<DeletedProduct>(deletedProduct);
            await deletedProductRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var deletedProduct = await deletedProductRepository.GetByIdAsync(id);
            if (deletedProduct != null)
            {
                await deletedProductRepository.DeleteAsync(id);
            }
        }
    }
}
