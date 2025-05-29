using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class AuditRepository : Repository<Audit, AuditDbContext>, IAuditRepository
    {
        private readonly AuditDbContext _ctx;
        private readonly MasterDbContext _master;

        public AuditRepository(AuditDbContext ctx, MasterDbContext masterDbContext)
            : base(ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _master = masterDbContext ?? throw new ArgumentNullException(nameof(masterDbContext));
        }

        public async Task<IEnumerable<Audit>> GetAllAsync()
        {
            return await _ctx.InventoryAudits
                             .AsNoTracking()
                             .ToListAsync();
        }

        public async Task<IEnumerable<Audit>> GetAllWithProductsAndEmployeeAsync()
        {
            var audits = await _ctx.InventoryAudits.ToListAsync();

            var empIds = audits.Select(a => a.EmployeeId).Distinct().ToList();
            var prodIds = audits.Select(a => a.ProductId).Distinct().ToList();

            var emps = await _master.Employees
                            .Where(e => empIds.Contains(e.EmployeeId))
                            .ToDictionaryAsync(e => e.EmployeeId);

            var prods = await _master.Products
                             .Where(p => prodIds.Contains(p.ProductId))
                             .ToDictionaryAsync(p => p.ProductId);

            foreach (var a in audits)
            {
                if (emps.TryGetValue(a.EmployeeId, out var e)) a.Employee = e;
                if (prods.TryGetValue(a.ProductId, out var p)) a.Product = p;
            }

            return audits;
        }

        public async Task<Audit> GetByIdAsync(int id)
        {
            return await _ctx.InventoryAudits.FindAsync(id);
        }

        public async Task AddAsync(Audit audit)
        {
            if (audit == null)
                throw new ArgumentNullException(nameof(audit));

            // --- 1) Проверяем наличие Product и Employee в masterDbContext ---
            bool productExists = await _master.Products
                .AsNoTracking()
                .AnyAsync(p => p.ProductId == audit.ProductId);

            if (!productExists)
                throw new InvalidOperationException($"Product with ID {audit.ProductId} not found.");

            bool employeeExists = await _master.Employees
                .AsNoTracking()
                .AnyAsync(e => e.EmployeeId == audit.EmployeeId);

            if (!employeeExists)
                throw new InvalidOperationException($"Employee with ID {audit.EmployeeId} not found.");

            // --- 2) Очищаем навигационные свойства, чтобы EF не пытался писать в чужие таблицы ---
            audit.Product = null;
            audit.Employee = null;

            // --- 3) Сохраняем только audit в своём контексте (AuditDbContext) ---
            await _ctx.InventoryAudits.AddAsync(audit);
            await _ctx.SaveChangesAsync();
        }



        public async Task UpdateAsync(Audit audit)
        {
            if (audit == null) throw new ArgumentNullException(nameof(audit));
            _ctx.InventoryAudits.Update(audit);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var audit = await _ctx.InventoryAudits.FindAsync(id);
            if (audit == null) throw new KeyNotFoundException("Audit not found");
            _ctx.InventoryAudits.Remove(audit);
            await _ctx.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _ctx.InventoryAudits
                             .AnyAsync(a => a.InventoryAuditId == id);
        }
    }
}
