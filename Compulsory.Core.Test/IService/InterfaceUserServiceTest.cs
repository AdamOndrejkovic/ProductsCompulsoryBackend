using Compulsory.Core.IServices;
using Compulsory.Domain.Services;
using Moq;
using Xunit;

namespace Compulsory.Core.Test.IService
{
    public class InterfaceUserServiceTest
    {
        private readonly Mock<IUserService> _service;

        public InterfaceUserServiceTest()
        {
            _service = new Mock<IUserService>();
        }

        [Fact]
        public void IUserService_Exists()
        {
            Assert.NotNull(_service.Object);
        }
        
        [Fact]
        public void UserIsAuthorized_ReturnsTrue()
        {
        }

        [Fact]
        public void UserIsNotAuthorized_ReturnsFalse()
        {
            
        }
    }
}