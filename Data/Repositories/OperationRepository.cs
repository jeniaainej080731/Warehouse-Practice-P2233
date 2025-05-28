using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Databases.Repositories.Context;
using Warehouse.Data.DTO;
using Warehouse.Data.Entities;
using Warehouse.Data.Interfaces;

namespace Warehouse.Data.Repositories
{
    public class OperationRepository : Repository<Operation, AuditDbContext>, IOperationRepository
    {
        private readonly AuditDbContext auditDbContext;
        private readonly MasterDbContext masterDbContext;
        public OperationRepository(AuditDbContext dbContext, MasterDbContext masterDbContext)
            : base(dbContext)
        {
            this.auditDbContext = dbContext;
            this.masterDbContext = masterDbContext;
        }

        public async Task<IEnumerable<OperationDto>> GetAllWithDetails()
        {
            // 1) Сначала полностью считаем все операции в память (AsNoTracking, чтобы не отслеживать их):
            var entities = dbSet
                .AsNoTracking()
                .ToList();

            // 2) Проецируем уже в памяти:
            var dtos = entities.Select(o => new OperationDto
            {
                OperationId = o.OperationId,
                ProductId = o.ProductId,
                SupplierId = o.SupplierId,
                EmployeeId = o.EmployeeId,
                OperationDate = o.OperationDate,
                OperationType = o.OperationType,
                QuantityInOperation = o.QuantityInOperation,
                ProductName = o.ProductName,
                SupplierName = o.SupplierName,
                EmployeeName = o.EmployeeName
            })
            .ToList();

            return dtos;
        }

        public async Task AddOperationAsync(Operation operation)
        {
            await auditDbContext.Operations.AddAsync(operation);
            await auditDbContext.SaveChangesAsync();
        }

        public async Task AddAsync(Operation entity)
        {
            try
            {
                await auditDbContext.Operations.AddAsync(entity);
                await auditDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                var inner = ex.InnerException?.Message ?? ex.Message;
                throw new Exception($"Error adding entity: {inner}", ex);
            }
        }

        public async Task<IEnumerable<OperationDto>> GetByProductIdAsync(int productId)
        {
            var operations = await dbSet
                .Where(o => o.ProductId == productId)
                .ToListAsync();

            var supplierIds = operations.Select(o => o.SupplierId).Distinct();
            var employeeIds = operations.Select(o => o.EmployeeId).Distinct();

            // Получаем связанные сущности из MasterDbContext
            var suppliers = await masterDbContext.Suppliers
                .Where(s => supplierIds.Contains(s.SupplierId))
                .ToDictionaryAsync(s => s.SupplierId);

            var employees = await masterDbContext.Employees
                .Where(e => employeeIds.Contains(e.EmployeeId))
                .ToDictionaryAsync(e => e.EmployeeId);

            var product = await masterDbContext.Products
                .FirstOrDefaultAsync(p => p.ProductId == productId);
            string productName = product?.ProductName ?? "Unknown";

            var dtos = operations.Select(o => new OperationDto
            {
                OperationId = o.OperationId,
                ProductId = o.ProductId,
                SupplierId = o.SupplierId,
                EmployeeId = o.EmployeeId,
                OperationDate = o.OperationDate,
                OperationType = o.OperationType,
                QuantityInOperation = o.QuantityInOperation,
                ProductName = productName,
                SupplierName = suppliers.TryGetValue(o.SupplierId, out var supplier) ? supplier.SupplierName : null,
                EmployeeName = employees.TryGetValue(o.EmployeeId, out var employee) ? employee.FullName : null
            });

            return dtos;
        }



        public async Task<IEnumerable<Operation>> GetBySupplierIdAsync(int supplierId)
        {
            return await Task.FromResult(dbSet.Where(o => o.SupplierId == supplierId).ToList());
        }

        public async Task<IEnumerable<Operation>> GetByEmployeeIdAsync(int employeeId)
        {
            return await Task.FromResult(dbSet.Where(o => o.EmployeeId == employeeId).ToList());
        }

        public async Task<IEnumerable<Operation>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await Task.FromResult(dbSet.Where(o => o.OperationDate >= startDate && o.OperationDate <= endDate).ToList());
        }

        public async Task<IEnumerable<Operation>> GetByTypeAsync(string operationType)
        {
            return await Task.FromResult(dbSet.Where(o => o.OperationType == operationType).ToList());
        }
    }
}
