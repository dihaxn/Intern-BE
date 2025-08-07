using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using JWT_Test.Models;
using Microsoft.AspNetCore.Authorization;

namespace JWT_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> _orders = new List<Order>
        {
            new Order { Id = 1, ProductId = 1, Quantity = 2, OrderDate = System.DateTime.Now },
            new Order { Id = 2, ProductId = 2, Quantity = 5, OrderDate = System.DateTime.Now }
        };

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orders;
        }
    }
}
