using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("test/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public string Get()
        {
            return "Hello from Get";
        }
    }
}
