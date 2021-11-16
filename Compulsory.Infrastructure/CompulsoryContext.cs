using Compulsory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compulsory.Infrastructure
{
    public class CompulsoryContext : DbContext
    {
        public CompulsoryContext(DbContextOptions<CompulsoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 30; i++)
            {
                modelBuilder.Entity<ProductEntity>()
                    .HasData(new ProductEntity()
                    {
                        Id = i,
                        Name = "Lego brick" + i,
                        Description = "Some description",
                        Price = 1.5 * i
                    });
            }
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<AdminEntity> Admins { get; set; }
    }
}