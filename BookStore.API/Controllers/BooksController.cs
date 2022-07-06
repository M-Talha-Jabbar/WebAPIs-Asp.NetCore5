using BookStore.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {

            var books = await this.bookRepository.GetAllBooksAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllBooks([FromRoute]int id)
        {

            var book = await this.bookRepository.GetBookByIdAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}
