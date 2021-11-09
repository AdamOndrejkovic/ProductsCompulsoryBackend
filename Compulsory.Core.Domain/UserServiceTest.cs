using System.IO;
using Compulsory.Core.IServices;
using Compulsory.Domain.IRepository;
using Compulsory.Domain.Services;
using Moq;
using Xunit;

namespace Compulsory.Core.Domain
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _mock;
        private readonly UserService _service;

        public UserServiceTest()
        {
            _mock = new Mock<IUserRepository>();
            _service = new UserService(_mock.Object);
        }

        [Fact]
        public void UserService_IsIUserService()
        {
            Assert.True(_service is IUserService);
        }

        [Fact]
        public void UserService_WithNullUserRepository_ThrowsExceptionWithMessage()
        {
            var exception = Assert.Throws<InvalidDataException>(
                (() => new UserService(null))
            );
            Assert.Equal("IUserRepository must be in constructor", exception.Message);
        }
    }
}