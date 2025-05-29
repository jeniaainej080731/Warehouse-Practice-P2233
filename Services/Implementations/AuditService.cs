using AutoMapper;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;
using Warehouse.Services.Interfaces;

namespace Warehouse.Services.Implementations
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _repo;
        private readonly IMapper _mapper;

        public AuditService(IAuditRepository repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<AuditDto>> GetAllAsync()
        {
            // 1) Получаем Audit-объекты вместе с навигациями из репозитория
            var audits = await _repo.GetAllWithProductsAndEmployeeAsync();

            // 2) Отфильтровываем те, у которых нет Product (удалён из справочника)
            var filtered = audits.Where(a => a.Product != null);

            // 3) Мапим в DTO и возвращаем
            return _mapper.Map<IEnumerable<AuditDto>>(filtered);
        }

        public async Task<AuditDto> GetByIdAsync(int id)
        {
            var audit = await _repo.GetByIdAsync(id);
            return audit == null ? null : _mapper.Map<AuditDto>(audit);
        }

        public async Task AddAsync(AuditDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var audit = _mapper.Map<Audit>(dto);
            await _repo.AddAsync(audit);
        }

        public async Task UpdateAsync(AuditDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            var existing = await _repo.GetByIdAsync(dto.InventoryAuditId);
            if (existing == null) throw new KeyNotFoundException("Audit not found");
            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var exists = await _repo.ExistsAsync(id);
            if (!exists) throw new KeyNotFoundException("Audit not found");
            await _repo.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repo.ExistsAsync(id);
        }
    }
}
