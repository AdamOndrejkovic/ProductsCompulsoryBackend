using System.Collections.Generic;
using System.IO;
using System.Linq;
using Compulsory.Core.Models;
using Compulsory.Domain.IRepository;
using Compulsory.Infrastructure.Entities;

namespace Compulsory.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly CompulsoryContext _compulsoryContext;

        public ProductRepository(CompulsoryContext compulsoryContext)
        {
            _compulsoryContext = compulsoryContext ?? throw new InvalidDataException("Product Repository must have a DB context in constructor");
        }

        public List<Product> GetAllProducts()
        {
            return _compulsoryContext.Products.Select(pe => new Product()
            {
                Id = pe.Id,
                Name = pe.Name,
                Description = pe.Description,
                Price = pe.Price
            }).ToList();
        }

        public bool DeleteProduct(int id)
        {
            var productToRemove = _compulsoryContext.Products.Where(p => p.Id == id);
            if (productToRemove != null)
            {
                _compulsoryContext.RemoveRange(productToRemove);
                _compulsoryContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateProduct(Product product)
        {
            var productToUpdate = _compulsoryContext.Products.Where(p => p.Id == product.Id);
            if (productToUpdate != null)
            {
                _compulsoryContext.Update(productToUpdate);
                _compulsoryContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool CreateProduct(Product product)
        {
            _compulsoryContext.Products.Add(new ProductEntity()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });
            _compulsoryContext.SaveChanges();
            return true;
        }
    }
}