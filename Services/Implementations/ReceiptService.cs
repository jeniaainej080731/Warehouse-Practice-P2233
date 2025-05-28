using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Repositories;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class ReceiptService : IReceiptService
    {
        private readonly ReceiptRepository receiptRepository;
        private readonly IMapper mapper;

        public ReceiptService(ReceiptRepository receiptRepository, IMapper mapper)
        {
            this.receiptRepository = receiptRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ReceiptDto>> GetAllAsync()
        {
            var receipts = await receiptRepository.GetAllAsync();
            return receipts.Select(r => mapper.Map<ReceiptDto>(r));
        }

        public async Task<ReceiptDto> GetByIdAsync(int id)
        {
            var receipt = await receiptRepository.GetByIdAsync(id);
            return mapper.Map<ReceiptDto>(receipt);
        }

        public async Task<ReceiptDto> AddAsync(ReceiptDto receiptDto)
        {
            var receipt = mapper.Map<Receipt>(receiptDto);
            var addedReceipt = await receiptRepository.AddReceiptWithTransactionAsync(receipt);
            return mapper.Map<ReceiptDto>(addedReceipt);
        }

        public async Task UpdateAsync(ReceiptDto receiptDto)
        {
            var receipt = mapper.Map<Receipt>(receiptDto);
            await receiptRepository.UpdateReceiptWithTransactionAsync(receipt);
        }

        public async Task DeleteAsync(int id)
        {
            await receiptRepository.DeleteReceiptWithTransactionAsync(id);
        }

        public async Task<IEnumerable<ReceiptDto>> GetByEmployeeIdAsync(int employeeId)
        {
            var receipts = await receiptRepository.GetByEmployeeIdAsync(employeeId);
            return receipts.Select(r => mapper.Map<ReceiptDto>(r));
        }

        public async Task<bool> ReceiptExistsAsync(int id)
        {
            return await receiptRepository.ReceiptExistsAsync(id);
        }

        public async Task<bool> ReceiptExistsByEmployeeIdAsync(int employeeId)
        {
            return await receiptRepository.ReceiptExistsByEmployeeIdAsync(employeeId);
        }
    }
}
