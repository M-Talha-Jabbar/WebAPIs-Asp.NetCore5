using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        // Built-in Attributes for Model Binding

        /*
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public int Population { get; set; }

        [BindProperty]
        public int Area { get; set; }   
        */ // OR (Shifting this properties into a separate model and then:)
        [BindProperty]
        public CountryModel Country { get; set; }

        [HttpPost("")]
        public IActionResult AddCountry() // [BindProperty] & [BindProperties]
        {
            // return Ok($"Name={this.Name}, Population={this.Population}, Area={this.Area}"); 
            return Ok($"Name={this.Country.Name}, Population={this.Country.Population}, Area={this.Country.Area}");
        }


        [HttpPost("FromQuery")]
        public IActionResult AddCountry([FromQuery]int id, [FromQuery]CountryModel model) // [FromQuery]
        {
            return Ok($"FromQuery Attribute: Id={id}, Name={model.Name}, Population={model.Population}, Area={model.Area}");
        }


        [HttpPost("FromRoute/{id}/{Name}/{Population}/{Area}")]
        public IActionResult AddCountry([FromRoute]string id, [FromRoute]CountryModel model) // [FromRoute]
        {
            return Ok($"FromRoute Attribute: Id={id}, Name={model.Name}, Population={model.Population}, Area={model.Area}");
        }


        [HttpPut("FromBody/{id}")]
        public IActionResult AddCountry([FromBody]CountryModel model, [FromRoute]string id) // [FromBody]
        {
            return Ok($"FromBody Attribute: Id={id}, Name={model.Name}, Population={model.Population}, Area={model.Area}");
        }


        [HttpPut("FromForm/{id}")]
        public IActionResult AddCountry([FromForm]CountryModel model, [FromRoute]int id) // [FromForm]
        {
            return Ok($"FromForm Attribute: Id={id}, Name={model.Name}, Population={model.Population}, Area={model.Area}");
        }


        [HttpPut("FromHeader/{id}")]
        public IActionResult AddCountry([FromHeader]CountryModel model, [FromHeader] string developer, [FromRoute]int id)
        {
            return Ok($"FromHeader Attribute: Id={id}, Developer={developer}, Name={model.Name}, Population={model.Population}, Area={model.Area}");
        }


        // URL/Endpoint should be unique for each action method irrespective of whether the action method is an overloaded method or not.

        // An URL/Endpoint is a combination of HTTP Action + Route of the resource.
        // So GET + /api/countries & POST + /api/countries both are unique URLs.
    }
}
