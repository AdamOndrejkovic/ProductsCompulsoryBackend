using System.Collections.Generic;
using Compulsory.Core.IServices;
using Compulsory.Core.Models;
using Moq;
using Xunit;

namespace Compulsory.Core.Test.IService
{
    public class InterfaceProductServiceTest
    {
        private readonly Mock<IProductService> _service;

        public InterfaceProductServiceTest()
        {
            _service = new Mock<IProductService>();
        }
        
        [Fact]
        public void IProductsService_Exists()
        {
            Assert.NotNull(_service.Object);
        }

        [Fact]
        public void GetAll_WithNoParams_ReturnsList()
        {
            var expectedList = new List<Product>()
            {
                new Product() { Id = 1, Name = "Iphone 13 Pro", Description = "It's a Pro", Price = 1000.00 },
                new Product() { Id = 2, Name = "Iphone 13", Description = "It's NOT a Pro", Price = 900.00 },
            };
            _service.Setup(ps => ps.GetAllProducts())
                .Returns(expectedList);
            
            Assert.Equal(expectedList, _service.Object.GetAllProducts());
        }

        [Fact]
        public void DeleteProduct_ReturnsTrue()
        {
            var expected = true;
            _service.Setup(ps => ps.DeleteProduct(1))
                .Returns(expected);
            
            Assert.Equal(expected, _service.Object.DeleteProduct(1));
        }
        
        [Fact]
        public void CreateProduct_ReturnsTrue()
        {
            var expected = true;
            var product = new Product(){ Id = 1, Name = "Iphone 13 Pro", Description = "It's a Pro", Price = 1000.00 };
            _service.Setup(ps => ps.CreateProduct(product))
                .Returns(expected);
            
            Assert.Equal(expected, _service.Object.CreateProduct(product));
        }
        
        [Fact]
        public void UpdateProduct_ReturnsTrue()
        {
            var expected = true;
            var product = new Product(){ Id = 1, Name = "Iphone 13 Pro", Description = "It's a Pro", Price = 1000.00 };
            _service.Setup(ps => ps.UpdateProduct(product))
                .Returns(expected);
            
            Assert.Equal(expected, _service.Object.UpdateProduct(product));
        }
    }
}