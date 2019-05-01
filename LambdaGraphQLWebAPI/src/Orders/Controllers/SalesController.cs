using Microsoft.AspNetCore.Mvc;

// for testing purpose to see if controller/action can be accessed from another project
namespace Orders.Controllers
{
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}