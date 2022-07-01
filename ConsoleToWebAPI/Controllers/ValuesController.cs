using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")] // Setting up the Base Route (i.e. Base URL) at the Controller level
    // After base url if you are using any further route on the action method then you need to append that URL into the base url.

    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Multiple URLs for a single resource (action method)
        [Route("get-all")]
        [Route("getall")]
        [Route("[controller]/[action]")] // Is Equal to [Route("values/getall")] // Token replacement in Routing
        [Route("[action]/[controller]")]
        /* The Route Attribute support token replacement. It means we can enclose the token (i.e. controller and action) within a pair of square-braces ([ ]). The tokens 
        (i.e. [controller] and [action]) are then replaced with the values of controller and action method name where the route is defined. */

        public string GetAll()
        {
            return "hello from get all";
        }

        [Route("get-all-authors")]
        [Route("~/getallauthors")] // If we donot want to use base route for a particular action method, then we need to override the base route.
        public string GetAllAuthors()
        {
            return "hello from get all authors";
        }

        [Route("books/{id}")] // Route Parameter
        public string GetById(int id)
        {
            return "Book Id: " + id;
        }

        [Route("books/{id}/author/{authorId}")]
        public string GetAuthorAddressById(int id, int authorId)
        {
            return "Author Id: " + authorId;
        }

        [Route("search")] // Query String
        // Query string should contain exact names as defined in action method parameters, irrespective of order of parameters.
        public string SearchBooks(int id, int authorId, string name, double rating, int price)
        {
            // default value of variable with type string is ""(Empty string) if we donot mention it in query string
            // default value of int, double, ... is 0 if we donot mention it in query string

            return $"Book Id: {id}\nAuthor Id: {authorId}\nName: {name}\nRating: {rating}\nPrice: {price}";
        }
    }
}
