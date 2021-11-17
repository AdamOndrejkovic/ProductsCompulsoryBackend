using System.Collections.Generic;
using Compulsory.Core.Models;

namespace Compulsory.Domain.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        bool DeleteProduct(int id); 
        bool UpdateProduct(Product product);
        bool CreateProduct(Product product);
        Product GetProductById(int id);
    }
}