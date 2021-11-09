using System.Collections.Generic;
using Compulsory.Core.Models;

namespace Compulsory.Core.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        bool DeleteProduct(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
    }
}