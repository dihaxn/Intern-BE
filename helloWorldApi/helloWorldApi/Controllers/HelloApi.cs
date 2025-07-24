using Microsoft.AspNetCore.Mvc;

namespace helloWorldApi.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class HelloApi: ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok("Sunny");
    }
}
