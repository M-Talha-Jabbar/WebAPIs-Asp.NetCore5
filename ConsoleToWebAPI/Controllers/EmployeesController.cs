using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // Action method return types
        public EmployeeModel CreateEmployees() // Specific Type
        {
            return new EmployeeModel() { Id = 1, Name = "Talha" };
        }

        public List<EmployeeModel> GetEmployees() // Specific Type
        {
            return new List<EmployeeModel>()
            {
                new EmployeeModel() { Id = 1, Name = "Talha" },
                new EmployeeModel() { Id = 2, Name = "Asad" }
            };
        }

        [Route("{id}")]
        public IActionResult GetEmployees(int id) // IActionResult
        {
            if(id == 0)
            {
                return NotFound();
            }

            return Ok(new List<EmployeeModel>()
            {
                new EmployeeModel() { Id = 1, Name = "Talha" },
                new EmployeeModel() { Id = 2, Name = "Asad" }
            });
        }

        [Route("{id}/basic")]
        public ActionResult<EmployeeModel> GetEmployeesBasicDetails(int id) // ActionResult<T>
        {
            if (id == 0)
            {
                return NotFound();
            }

            return new EmployeeModel() { Id = 2, Name = "Asad" };
        }
    }
}
