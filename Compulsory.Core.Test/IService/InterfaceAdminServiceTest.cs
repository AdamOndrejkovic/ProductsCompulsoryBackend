using Compulsory.Core.IServices;
using Moq;
using Xunit;

namespace Compulsory.Core.Test.IService
{
    public class InterfaceAdminServiceTest
    {
        private readonly Mock<IAdminService> _service;

        public InterfaceAdminServiceTest()
        {
            _service = new Mock<IAdminService>();
        }
        
        [Fact]
        public void IAdminService_Exists()
        {
            Assert.NotNull(_service.Object);
        }

        [Fact]
        public void AdminIsAuthorized_ReturnsTrue()
        {
            
        }

        [Fact]
        public void AdminIsNotAuthorized_ReturnsFalse()
        {
            
        }


    }
}