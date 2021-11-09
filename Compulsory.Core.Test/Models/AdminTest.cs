using Compulsory.Core.Models;
using Xunit;

namespace Compulsory.Core.Test
{
    public class AdminTest
    {
        private readonly Admin _admin;

        public AdminTest()
        {
            _admin = new Admin();
        }
        
        [Fact]
        public void AdminClass_Exists()
        {
            Assert.NotNull(_admin);
        }

        [Fact]
        public void AdminClass_HasId_WithTypeId()
        {
            var expected = 1;
            _admin.Id = 1;
            Assert.Equal(expected, _admin.Id);
            Assert.True(_admin.Id is int);
        }

        [Fact]
        public void AdminClass_HasUserName_WithTypeString()
        {
            var expected = "GodAccount";
            _admin.Username = "GodAccount";
            Assert.Equal(expected, _admin.Username);
            Assert.True(_admin.Username is string);
        }

        [Fact]
        public void AdminClass_HasPassword_WithTypeString()
        {
            var expected = "BigBoss";
            _admin.Password = "BigBoss";
            Assert.Equal(expected, _admin.Password);
            Assert.True(_admin.Password is string);
        }

        [Fact]
        public void AdminClass_HasCanCreate_WithTypeBoolean()
        {
            var expected = true;
            _admin.CanCreate = true;
            Assert.Equal(expected, _admin.CanCreate);
            Assert.True(_admin.CanCreate is bool);
        }

        [Fact]
        public void AdminClass_HasCanUpdate_WithTypeBoolean()
        {
            var expected = true;
            _admin.CanUpdate = true;
            Assert.Equal(expected, _admin.CanUpdate);
            Assert.True(_admin.CanUpdate is bool);
        }

        [Fact]
        public void AdminClass_HasCanDelete_WithTypeBoolean()
        {
            var expected = true;
            _admin.CanDelete = true;
            Assert.Equal(expected, _admin.CanDelete);
            Assert.True(_admin.CanDelete is bool);
        }
    }
}