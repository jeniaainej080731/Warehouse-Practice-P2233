using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Databases.Repositories.Context
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<LoginRole> LoginRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Fields configuration LoginRole
            modelBuilder.Entity<LoginRole>()
                .Property(lr => lr.Login)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<LoginRole>()
                .Property(lr => lr.Password)
                .IsRequired();

            modelBuilder.Entity<LoginRole>()
                .Property(lr => lr.Role)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.LoginRole)
                .WithMany(lr => lr.Employees)
                .HasForeignKey(e => e.Login_Id);

        }
    }
}
