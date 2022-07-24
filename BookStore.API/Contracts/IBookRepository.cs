using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(BookModel bookModel); // POST
        Task DeleteBookAsync(int bookId); // DELETE
        Task<List<BookModel>> GetAllBooksAsync(); // GET
        Task<BookModel> GetBookByIdAsync(int bookId); // GET
        Task UpdateBookAsync(int bookId, BookModel bookModel); // PUT
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel); // PATCH
    }
}
