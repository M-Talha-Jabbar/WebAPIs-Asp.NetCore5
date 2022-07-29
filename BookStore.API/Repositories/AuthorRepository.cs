using BookStore.API.Contracts;
using BookStore.API.Data;
using BookStore.API.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoreContext _context;

        public AuthorRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<AuthorViewModel> GetAuthorByIdAsync(int id)
        {
            var author = await _context.Authors.Where(a => a.Id == id)
                .Select(x => new AuthorViewModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     AuthorAddressId = x.AuthorAddressId,
                 })
                .FirstOrDefaultAsync();

            return author;
        }
    }
}
