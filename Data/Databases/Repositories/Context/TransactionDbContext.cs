using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Databases.Repositories.Context
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<ReceiptDetails> ReceiptDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Invoice -> Supplier
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Supplier)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.SupplierId);

            // Invoice -> Employee
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Employee)
                .WithMany(e => e.Invoices)
                .HasForeignKey(i => i.EmployeeId);

            // InvoiceDetails -> Invoice
            modelBuilder.Entity<InvoiceDetails>()
                .HasOne(id => id.Invoice)
                .WithOne()
                .HasForeignKey<InvoiceDetails>(id => id.InvoiceId);

            // InvoiceDetails -> Product
            modelBuilder.Entity<InvoiceDetails>()
                .HasOne(id => id.Product)
                .WithMany(p => p.InvoiceDetails)
                .HasForeignKey(id => id.ProductId);

            // Receipt -> Employee
            modelBuilder.Entity<Receipt>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Receipts)
                .HasForeignKey(r => r.EmployeeId);

            // ReceiptDetails -> Receipt
            modelBuilder.Entity<ReceiptDetails>()
                .HasOne(rd => rd.Receipt)
                .WithOne()
                .HasForeignKey<ReceiptDetails>(rd => rd.ReceiptId);

            // ReceiptDetails -> Product
            modelBuilder.Entity<ReceiptDetails>()
                .HasOne(rd => rd.Product)
                .WithMany(p => p.ReceiptDetails)
                .HasForeignKey(rd => rd.ProductId);
        }
    }
}
