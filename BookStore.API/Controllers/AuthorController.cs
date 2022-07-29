using BookStore.API.Contracts;
using BookStore.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById([FromRoute]int id)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(id);

            return Ok(author);
        }
    }
}
