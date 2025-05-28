using AutoMapper;
using System.Transactions;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class OperationService : IOperationService
    {
        private readonly OperationRepository operationRepository;
        private readonly IMapper mapper;

        public OperationService(OperationRepository operationRepository, IMapper mapper)
        {
            this.operationRepository = operationRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<OperationDto>> GetAllAsync()
        {
            var operations = await operationRepository.GetAllAsync();
            return operations.Select(op => mapper.Map<OperationDto>(op));
        }

        public async Task<OperationDto> GetByIdAsync(int id)
        {
            var operation = await operationRepository.GetByIdAsync(id);
            return mapper.Map<OperationDto>(operation);
        }

        public async Task<OperationDto> GetByProductIdAsync(int productId)
        {
            var operations = await operationRepository.GetByProductIdAsync(productId);
            return operations.Select(op => mapper.Map<OperationDto>(op)).FirstOrDefault();
        }

        public async Task<IEnumerable<OperationDto>> GetAllWithDetailsAsync()
        {
            var operations = await operationRepository.GetAllWithDetails();
            return operations.Select(op => mapper.Map<OperationDto>(op));
        }

        public async Task AddAsync(OperationDto operation)
        {
            var entity = mapper.Map<Operation>(operation);

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                await operationRepository.AddAsync(entity);

                scope.Complete();
            }
        }

        public async Task UpdateAsync(OperationDto operation)
        {
            var entity = mapper.Map<Operation>(operation);
            await operationRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await operationRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await operationRepository.ExistsAsync(id);
        }
    }
}
