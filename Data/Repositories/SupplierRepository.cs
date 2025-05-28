using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class SupplierRepository : Repository<Supplier, MasterDbContext>, ISupplierRepository
    {
        private readonly MasterDbContext masterDbContext;

        public SupplierRepository(MasterDbContext masterDbContext)
            : base(masterDbContext)
        {
            this.masterDbContext = masterDbContext;
        }

        public async Task<IEnumerable<Supplier>> GetByNameAsync(string name)
        {
            return await dbSet
                .Where(s => s.SupplierName.Contains(name))
                .ToListAsync();
        }

        public async Task<Supplier> GetByIdWithInvoicesAsync(int id)
        {
            return await dbSet
                .Include(s => s.Invoices)
                .FirstOrDefaultAsync(s => s.SupplierId == id);
        }

        public async Task<Supplier> GetByIdWithOperationsAsync(int id)
        {
            return await dbSet
                .Include(s => s.Operations)
                .FirstOrDefaultAsync(s => s.SupplierId == id);
        }

        public async Task<Supplier> GetByIdWithInvoicesAndOperationsAsync(int id)
        {
            return await dbSet
                .Include(s => s.Invoices)
                .Include(s => s.Operations)
                .FirstOrDefaultAsync(s => s.SupplierId == id);
        }
    }
}
