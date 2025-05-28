using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await supplierRepository.GetAllAsync();
            return suppliers.Select(s => new SupplierDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName,
                ContactInfo = s.ContactInfo,
                SupplierAddress = s.SupplierAddress,
                PhotoPath = s.PhotoPath
            });
        }

        public async Task<SupplierDto> GetByIdAsync(int id)
        {
            var supplier = await supplierRepository.GetByIdAsync(id);
            if (supplier == null) return null;

            return new SupplierDto
            {
                SupplierId = supplier.SupplierId,
                SupplierName = supplier.SupplierName,
                ContactInfo = supplier.ContactInfo,
                SupplierAddress = supplier.SupplierAddress,
                PhotoPath = supplier.PhotoPath
            };
        }

        public async Task<SupplierDto> AddAsync(SupplierDto supplierDto)
        {
            var supplier = new Supplier
            {
                SupplierName = supplierDto.SupplierName,
                ContactInfo = supplierDto.ContactInfo,
                SupplierAddress = supplierDto.SupplierAddress,
                PhotoPath = supplierDto.PhotoPath
            };

            await supplierRepository.AddAsync(supplier);

            supplierDto.SupplierId = supplier.SupplierId;
            return supplierDto;
        }

        public async Task UpdateAsync(SupplierDto supplierDto)
        {
            var supplier = await supplierRepository.GetByIdAsync(supplierDto.SupplierId);
            if (supplier == null)
                throw new Exception($"Поставщик с Id={supplierDto.SupplierId} не найден");

            supplier.SupplierName = supplierDto.SupplierName;
            supplier.ContactInfo = supplierDto.ContactInfo;
            supplier.SupplierAddress = supplierDto.SupplierAddress;
            supplier.PhotoPath = supplierDto.PhotoPath;

            await supplierRepository.UpdateAsync(supplier);
        }


        public async Task DeleteAsync(int id)
        {
            await supplierRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<SupplierDto>> GetByNameAsync(string name)
        {
            var suppliers = await supplierRepository.GetByNameAsync(name);
            return suppliers.Select(s => new SupplierDto
            {
                SupplierId = s.SupplierId,
                SupplierName = s.SupplierName,
                ContactInfo = s.ContactInfo,
                SupplierAddress = s.SupplierAddress,
                PhotoPath = s.PhotoPath
            });
        }
    }
}
