using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Models;
using Task2.Services.Interfaces;

namespace Task2.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products = new();

        public IEnumerable<Product> GetAll() => _products;

        public Product Get(int id) =>
            _products.FirstOrDefault(p => p.Id == id);

        public Product Create(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return product;
        }

        public void Update(int id, Product product)
        {
            var existing = Get(id);
            if (existing is null) return;
            existing.Name = product.Name;
            existing.Price = product.Price;
        }

        public void Delete(int id)
        {
            var product = Get(id);
            if( product != null) _products.Remove(product);
        }
    }
}
