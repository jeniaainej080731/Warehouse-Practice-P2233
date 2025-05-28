using Microsoft.EntityFrameworkCore;
using Warehouse.Data.Entities;

namespace Warehouse.Data.Databases.Repositories.Context
{
    public class MediaDbContext : DbContext
    {
        public MediaDbContext(DbContextOptions<MediaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Photo -> Product (Link)
            modelBuilder.Entity<Photo>()
                .Property(p => p.PhotoPath)
                .IsRequired();
        }
    }
}
