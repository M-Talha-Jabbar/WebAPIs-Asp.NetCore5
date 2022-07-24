using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync() // do async programming whenever you have to interact with the database.
        {
            //var records = _context.Books.ToList(); // Since we are using async programming so:
            //var records = _context.Books.ToListAsync(); // As of now 'records' contains List<Books> but we have to return List<BookModel>.
            // So now we have to convert this data in 'records' from List<Books> to List<BookModel>.
            // First approach is using foreach loop.
            // Second approach is fetching data directly into the BookModel and that is what we are going to do.
            /*
            var records = await _context.Books.Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).ToListAsync();

            return records;
            */

            // Using AutoMapper
            var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            /*
            var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
            }).FirstOrDefaultAsync();
            // Difference between First() & FirstOrDefault() :
            // If you couldn't find the book, then with First() it will give you an error.
            // But for the same scenario FirstOrDefault() will return a null value and there will not be any error.

            return record;
            */

            // Using Automapper
            var book = await _context.Books.FindAsync(bookId);
            return _mapper.Map<BookModel>(book);

            // If names are different to each other then you need to define those mappings in Profile (ApplicationMapper.cs)
        }

        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            _context.Books.Add(book);
            // At this point, the application will not hit the database. To hit the database we have to save all changes. For that we can use:
            await _context.SaveChangesAsync(); // Here book 'Id' will be generated and will be automatically saved into 'book' object here.

            return book.Id;
        }

        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            /*
            // For updating an item we are hitting database two times

            // First One
             var book = await _context.Books.FindAsync(bookId); // Find() only works with PK

            if(book != null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;

                _context.Books.Update(book);

                // Second One
                await _context.SaveChangesAsync();
            }

            // This can cause performace issues.
            */


           // Now updating an item in single database call

           var book = new Books()
           {
               Id = bookId,
               Title = bookModel.Title,
               Description = bookModel.Description
           };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);

            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            /*
            // For deleting an item we are hitting database two times

            // First One
            var book = _context.Books.Where(x => x.Id == bookId).FirstOrDefault();

            _context.Books.Remove(book);

            // Second One
            await _context.SaveChangesAsync();

            // This can cause performace issues.
            */


            // Now deleting an item in single database call

            var book = new Books()
            {
                Id = bookId,
            };

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            // If we does not have PK then first approach where we are hitting database twice will be used.
        }
    }
}
