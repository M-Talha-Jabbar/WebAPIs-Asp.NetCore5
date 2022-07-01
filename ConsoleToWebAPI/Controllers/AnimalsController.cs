using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<AnimalModel> animals = null;
        public AnimalsController() { 
            animals = new List<AnimalModel>()
            {
                new AnimalModel(){ Id = 1, Name = "Eagle" },
                new AnimalModel(){ Id = 2, Name = "Lion" }
            };
        }

        public IActionResult GetAnimals()
        {
            return Ok(animals);
        }

        [Route("test")]
        public IActionResult GetAnimallsTest()
        {
            //return LocalRedirect("~/api/Animals"); // HTTP Status Code: 302
            return LocalRedirectPermanent("~/api/Animals"); // HTTP Status Code: 301

            // With LocalRedirect() and LocalRedirectPermanent() you can only redirect to an local url (same domain).
            // With Redirect() you can also redirect to an external url (different domain).
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var animal = animals.FirstOrDefault(x => x.Id == id);

            if(animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        /*
        [Route("")]
        [HttpPost]
        */ // OR
        [HttpPost("")] 
        public IActionResult CreateAnimal(AnimalModel animal) // URL: api/Animals/
        {
            animals.Add(animal);

            return Created("~/api/Animals/"+animal.Id, animal); // (URI at which the content has been created, data to be return in the response body)
        }
    }
}
