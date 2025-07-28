using Microsoft.AspNetCore.Mvc;
using Task2.Models;
using Task2.Services.Interfaces;

namespace Task2.Controllers.v1
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _svc;
        public ProductController(IProductService svc) => _svc = svc;

        [HttpGet]
        public IActionResult GetAll() => Ok(_svc.GetAll());
    
        [HttpGet("{id}")]
        public IActionResult Get(int id) => _svc.Get(id) is Product p ? Ok(p) : NotFound();     

        [HttpPost]
        public IActionResult Create([FromBody] Product p)
        {
            var created = _svc.Create(p);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product p)
        {
            _svc.Update(id, p);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _svc.Delete(id);
            return NoContent();
        }
    }
}
