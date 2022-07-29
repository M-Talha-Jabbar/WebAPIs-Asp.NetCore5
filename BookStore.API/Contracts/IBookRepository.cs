using BookStore.API.Models;
using BookStore.API.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(BookViewModel bookModel); // POST
        Task DeleteBookAsync(int bookId); // DELETE
        Task<List<BookViewModel>> GetAllBooksAsync(); // GET
        Task<BookViewModel> GetBookByIdAsync(int bookId); // GET
        Task UpdateBookAsync(int bookId, BookViewModel bookModel); // PUT
        Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel); // PATCH
        Task<List<DuplicateBookViewModel>> GetAllDuplicateBooksByIdAsync(int bookId); // GET
    }
}
