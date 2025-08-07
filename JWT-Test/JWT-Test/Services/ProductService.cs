using JWT_Test.Models;
using System.Collections.Generic;
using System.Linq;

namespace JWT_Test.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Mouse", Price = 40 }
        };

        public IEnumerable<Product> GetProducts() => _products;

        public Product GetProduct(int id) => _products.FirstOrDefault(p => p.Id == id);
    }
}
