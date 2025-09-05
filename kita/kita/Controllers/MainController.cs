    using Microsoft.AspNetCore.Mvc;

    namespace kita.Controllers;

    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API is running");
        }
        
        [HttpPost]
        public IActionResult Post()
        {
            return Ok("API is running");
        }
        
        
    }