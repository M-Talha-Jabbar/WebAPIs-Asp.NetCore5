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

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody]AuthorViewModel authorViewModel)
        {
            var authorId = await _authorRepository.AddAuthorAsync(authorViewModel);

            return CreatedAtAction("GetAuthorById", new { id = authorId }, new { authorId });
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAuthorBooks([FromRoute]int id)
        {
            var authorBooks = await _authorRepository.GetAuthorBooksAsync(id);

            return Ok(authorBooks);
        }
    }
}
