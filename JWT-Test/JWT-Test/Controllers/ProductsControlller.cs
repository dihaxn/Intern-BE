using Microsoft.AspNetCore.Mvc;
using JWT_Test.Services;
using System.Collections.Generic;
using JWT_Test.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWT_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetProducts();
        }
    }
}
