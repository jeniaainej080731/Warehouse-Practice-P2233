using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Databases.Repositories.Context
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options)
            : base(options)
        {
        }

        public DbSet<DeletedProduct> DeletedProducts { get; set; }
        public DbSet<Audit> InventoryAudits { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DeletedProduct -> Product
            modelBuilder.Entity<DeletedProduct>()
                .HasOne(dp => dp.Product)
                .WithOne()
                .HasForeignKey<DeletedProduct>(dp => dp.ProductId);

            // InventoryAudit -> Product
            modelBuilder.Entity<Audit>()
                .HasOne(ia => ia.Product)
                .WithMany(p => p.InventoryAudits)
                .HasForeignKey(ia => ia.ProductId);

            // InventoryAudit -> Employee
            modelBuilder.Entity<Audit>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.InventoryAudits)
                .HasForeignKey(a => a.EmployeeId);

            // Operation -> Product
            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Product)
                .WithMany(e => e.Operations)
                .HasForeignKey(o => o.ProductId);

            // Operation -> Employee
            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Operations)
                .HasForeignKey(o => o.ProductId);

            // Operation -> Supplier
            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Supplier)
                .WithMany(e => e.Operations)
                .HasForeignKey(o => o.SupplierId);
        }
    }
}
