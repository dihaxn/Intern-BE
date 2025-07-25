using Microsoft.AspNetCore.Mvc;
using ECommerceApi.Models;

namespace ECommerceApi.AddControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    { 

         // GET: api/product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            // Return a hard-coded list
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Sample Item", Price = 9.99M }
            };

            return Ok(products);
        }









    }











}