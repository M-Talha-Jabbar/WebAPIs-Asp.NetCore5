using BookStore.API.Models;
using BookStore.API.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
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
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        { 
            var book = await this.bookRepository.GetBookByIdAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody]BookViewModel bookModel)
        {
            var id = await bookRepository.AddBookAsync(bookModel);

            return CreatedAtAction("GetBookById", new { id = id }, new { id }); // (action name, route values, response data)
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]BookViewModel bookModel)
        {
            await bookRepository.UpdateBookAsync(id, bookModel);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatch([FromRoute]int id, JsonPatchDocument bookModel)
        {
            await bookRepository.UpdateBookPatchAsync(id, bookModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute]int id)
        {
            await bookRepository.DeleteBookAsync(id);

            return Ok();
        }

        [HttpGet("{id}/DuplicateBooks")]
        public async Task<IActionResult> GetAllDuplicateBooksById([FromRoute]int id)
        {
            var books = await bookRepository.GetAllDuplicateBooksByIdAsync(id);

            return Ok(books);
        }
    }
}
