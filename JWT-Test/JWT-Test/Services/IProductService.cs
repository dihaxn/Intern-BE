using JWT_Test.Models;
using System.Collections.Generic;

namespace JWT_Test.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
    }
}
