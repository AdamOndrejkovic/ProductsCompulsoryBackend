using System;
using Compulsory.Core.Models;
using Xunit;

namespace Compulsory.Core.Test
{
    public class ProductTest
    {
        private readonly Product _product;

        public ProductTest()
        {
            _product = new Product();
        }
        
        [Fact]
        public void ProductClass_Exists()
        {
            Assert.NotNull(_product);
        }

        [Fact]
        public void ProductClass_HasId_WithTypeInt()
        {
            var expected = 1;
            _product.Id = 1;
            Assert.Equal(expected, _product.Id);
            Assert.True(_product.Id is int);
        }

        [Fact]
        public void ProductClass_HasName_WithTypeString()
        {
            var expected = "Laptop";
            _product.Name = "Laptop";
            Assert.Equal(expected, _product.Name);
            Assert.True(_product.Name is string);
        }

        [Fact]
        public void ProductClass_HasDescription_WithTypeString()
        {
            var expected = "New MacBook Pro";
            _product.Description = "New MacBook Pro";
            Assert.Equal(expected, _product.Description);
            Assert.True(_product.Description is string);
        }

        [Fact]
        public void ProductClass_HasPrice_WithTypeDouble()
        {
            var expected = 250.00;
            _product.Price = 250.00;
            Assert.Equal(expected, _product.Price);
            Assert.True(_product.Price is double);
        }

        [Fact]
        public void Equals_ProductWithSameProperties_ReturnTrue()
        {
            var product1 = new Product() { Id = 1, Name = "Laptop", Description = "New MacBook Pro", Price = 250.00 };
            var product2 = new Product() { Id = 1, Name = "Laptop", Description = "New MacBook Pro", Price = 250.00 };
            Assert.True(product1.Equals(product2));
            Assert.True(product2.Equals(product1));
        }
        
        [Fact]
        public void NotEquals_ProductWithDiffrentProperties_ReturnFalse()
        {
            var product1 = new Product() { Id = 1, Name = "Laptop", Description = "New MacBook Pro", Price = 250.00 };
            var product2 = new Product() { Id = 1, Name = "Laptop", Description = "Old MacBook Pro", Price = 250.00 };
            Assert.False(product1.Equals(product2));
            Assert.False(product2.Equals(product1));
        }
    }
}