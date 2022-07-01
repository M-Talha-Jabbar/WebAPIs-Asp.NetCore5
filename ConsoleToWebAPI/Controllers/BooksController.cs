using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // Route Constraints

        [Route("{id:int:min(10):max(100)}")] 
        /* If you make a hit on /api/books/9 then you will see that second action method will be called (Return Output: Hello String: 9) b/c by default all the route 
        parameter sare string. */
        public string GetById(int id) 
        {
            return "Hello int: " + id;
        }
        
        [Route("{id:minlength(1)}")] // By default all the Route parameters are string, so no need to define string type here.
        public string GetByIdString(string id)
        {
            return "Hello string: " + id;
        }

        /*
        [Route("{id:regex(a(b|c))}")]
        public string GetByIdRegex(string id)
        {
            return "Hello regex: " + id;
        }
        */

        // Notice all action methods have unique URLs b/c the type and structure of Route parameter is different in all.
    }
}
