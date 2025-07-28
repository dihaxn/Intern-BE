using System.Collections.Generic;
using Task2.Models;

namespace Task2.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Create(Product product);
        void Update(int id, Product product);
        void Delete(int id);
    }
}