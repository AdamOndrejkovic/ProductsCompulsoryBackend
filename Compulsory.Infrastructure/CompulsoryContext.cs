using Compulsory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Compulsory.Infrastructure
{
    public class CompulsoryContext: DbContext
    {
        public CompulsoryContext(DbContextOptions<CompulsoryContext> options): base(options){}
        

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<AdminEntity> Admins { get; set; }
    }
}