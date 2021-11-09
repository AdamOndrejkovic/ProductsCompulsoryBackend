using Compulsory.Core.Models;
using Xunit;

namespace Compulsory.Core.Test
{
    public class UserTest
    {
        private readonly User _user;

        public UserTest()
        {
            _user = new User();
        }
        
        [Fact]
        public void UserClass_Exists()
        {
            Assert.NotNull(_user);
        }

        [Fact]
        public void UserClass_HasId_WithTypeInt()
        {
            var expected = 1;
            _user.Id = 1;
            Assert.Equal(expected, _user.Id);
            Assert.True(_user.Id is int);
        }

        [Fact]
        public void UserClass_HasUserName_WithTypeString()
        {
            var expected = "Batman";
            _user.Username = "Batman";
            Assert.Equal(expected, _user.Username);
            Assert.True(_user.Username is string);
        }

        [Fact]
        public void UserClass_HasEmail_WithTypeString()
        {
            var expected = "bat@mail.com";
            _user.Email = "bat@mail.com";
            Assert.Equal(expected, _user.Email);
            Assert.True(_user.Email is string);
        }

        [Fact]
        public void UserClass_HasPassword_WithTypeString()
        {
            var expected = "I-AM-BATMAN";
            _user.Password = "I-AM-BATMAN";
            Assert.Equal(expected, _user.Password);
            Assert.True(_user.Password is string);
        }

        [Fact]
        public void Equals_UserClassWithSameProperties_ReturnTrue()
        {
            var user1 = new User() { Id = 1, Username = "Batman", Email = "bat@mail.com", Password = "I-AM-BATMAN" };
            var user2 = new User() { Id = 1, Username = "Batman", Email = "bat@mail.com", Password = "I-AM-BATMAN" };
            Assert.True(user1.Equals(user2));
            Assert.True(user2.Equals(user1));
        }

        [Fact]
        public void NotEquals_UserClassWithSameProperties_ReturnFalse()
        {
            var user1 = new User() { Id = 1, Username = "Batman", Email = "bat@mail.com", Password = "I-AM-BATMAN" };
            var user2 = new User() { Id = 1, Username = "Superman", Email = "bat@mail.com", Password = "I-AM-BATMAN" };
            Assert.False(user1.Equals(user2));
            Assert.False(user2.Equals(user1));
        }
        
        
    }
}