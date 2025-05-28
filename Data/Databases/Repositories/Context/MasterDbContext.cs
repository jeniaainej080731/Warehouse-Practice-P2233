using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Databases.Repositories.Context
{
    public class MasterDbContext : DbContext
    {
        public MasterDbContext(DbContextOptions<MasterDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Links Employee
            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Receipts)
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Employee)
                .WithMany(e => e.Invoices)
                .HasForeignKey(i => i.EmployeeId);

            modelBuilder.Entity<Audit>()
                .HasOne(ia => ia.Employee)
                .WithMany(e => e.InventoryAudits)
                .HasForeignKey(ia => ia.EmployeeId);

            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Operations)
                .HasForeignKey(o => o.EmployeeId);

            // Links Supplier
            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Supplier)
                .WithMany(s => s.Operations)
                .HasForeignKey(o => o.SupplierId);

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.SupplierId);

            // Links Category -> Products
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Product -> Operations, ReceiptDetails, InvoiceDetails, InventoryAudits
            modelBuilder.Entity<Operation>()
                .HasOne(o => o.Product)
                .WithMany(p => p.Operations)
                .HasForeignKey(o => o.ProductId);

            modelBuilder.Entity<ReceiptDetails>()
                .HasOne(rd => rd.Product)
                .WithMany(p => p.ReceiptDetails)
                .HasForeignKey(rd => rd.ProductId);

            modelBuilder.Entity<InvoiceDetails>()
                .HasOne(id => id.Product)
                .WithMany(p => p.InvoiceDetails)
                .HasForeignKey(id => id.ProductId);

            modelBuilder.Entity<Audit>()
                .HasOne(ia => ia.Product)
                .WithMany(p => p.InventoryAudits)
                .HasForeignKey(ia => ia.ProductId);
        }
    }
}
