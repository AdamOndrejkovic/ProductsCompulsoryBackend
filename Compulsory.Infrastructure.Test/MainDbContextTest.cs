using Compulsory.Infrastructure.Entities;
using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Compulsory.Infrastructure.Test
{
    public class MainDbContextTest
    {
        private readonly CompulsoryContext _mockedDbContext;

        public MainDbContextTest()
        {
            _mockedDbContext = Create.MockedDbContextFor<CompulsoryContext>();
        }

        [Fact]
        public void DbContext_WithDbContextOptions_IsAvailable()
        {
            Assert.NotNull(_mockedDbContext);
        }

        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeProduct()
        {
            Assert.True(_mockedDbContext.Products is DbSet<ProductEntity>);
        }
        
        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeUser()
        {
            Assert.True(_mockedDbContext.Users is DbSet<UserEntity>);
        }
        
        [Fact]
        public void DbContext_DbSets_MustHaveDbSetWithTypeAdmin()
        {
            Assert.True(_mockedDbContext.Admins is DbSet<AdminEntity>);
        }
        
    }
}