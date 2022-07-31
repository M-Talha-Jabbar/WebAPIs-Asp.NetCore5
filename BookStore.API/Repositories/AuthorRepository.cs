using BookStore.API.Contracts;
using BookStore.API.Data;
using BookStore.API.Data.Models;
using BookStore.API.Models;
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
            var author = await _context.Authors
                .Where(a => a.Id == id)
                .Include(a => a.AuthorAddress)
                .Select(x => new AuthorViewModel()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     AuthorAddressId = x.AuthorAddressId,
                     AuthorAddress = x.AuthorAddress
                 })
                .FirstOrDefaultAsync();

            return author;
        }

        public async Task<int> AddAuthorAsync(AuthorViewModel authorViewModel)
        {
            var authorAddress = new AuthorAddress()
            {
                Location = authorViewModel.AuthorAddress.Location
            };

            _context.AuthorsAddress.Add(authorAddress);

            await _context.SaveChangesAsync();

            var author = new Author() 
            {
                Name = authorViewModel.Name,
                AuthorAddressId = authorAddress.Id
            };

            _context.Authors.Add(author);

            await _context.SaveChangesAsync();

            return author.Id;
        }

        public async Task<AuthorBooksViewModel> GetAuthorBooksAsync(int id)
        {
            var authorBooks = await _context.Authors
                .Where(a => a.Id == id)
                .Include(a => a.Books)
                .Select(x => new AuthorBooksViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Books = x.Books.Select(z => new BookViewModel()
                    {
                        Id = z.Id,
                        Title = z.Title,
                        Description = z.Description
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();

            return authorBooks;
        }
    }
}
