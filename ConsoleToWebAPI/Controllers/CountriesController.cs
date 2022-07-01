using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
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
        public IActionResult AddCountry()
        {
            // return Ok($"Name={this.Name}, Population={this.Population}, Area={this.Area}"); 
            return Ok($"Name={this.Country.Name}, Population={this.Country.Population}, Area={this.Country.Area}");
        }
    }
}
