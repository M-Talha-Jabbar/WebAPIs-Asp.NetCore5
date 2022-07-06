using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync() // do async programming whenever you have to interact with the database.
        {
            //var records = _context.Books.ToList(); // Since we are using async programming so:
            //var records = _context.Books.ToListAsync(); // As of now 'records' contains List<Books> but we have to return List<BookModel>.
            // So now we have to convert this data in 'records' from List<Books> to List<BookModel>.
            // First approach is using foreach loop.
            // Second approach is fetching data directly into the BookModel and that is what we are going to do.
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();

            return records;
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefaultAsync();

            return record;
        }
    }
}
