using System.IO;
using Compulsory.Core.IServices;
using Compulsory.Domain.IRepository;
using Compulsory.Domain.Services;
using Moq;
using Xunit;

namespace Compulsory.Core.Domain
{
    public class AdminServiceTest
    {
        private readonly Mock<IAdminRepository> _mock;
        private readonly AdminService _service;

        public AdminServiceTest()
        {
            _mock = new Mock<IAdminRepository>();
            _service = new AdminService(_mock.Object);
        }
        
        [Fact]
        public void AdminService_IsIAdminService()
        {
            Assert.True(_service is IAdminService);
        }

        [Fact]
        public void AdminService_WithNullAdminRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                (() =>
                {
                    new AdminService(null);
                })
            );
            Assert.Equal("Admin repository can not be null", exception.Message);
        }
    }
}