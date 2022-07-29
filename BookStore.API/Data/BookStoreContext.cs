using BookStore.API.Data.Models;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    // public class BookStoreContext : DbContext
    // Sine now we are dealing with Identity Core so DbContext will be replaced with IdentityDbContext.

    // public class BookStoreContext : IdentityDbContext
    // Since we further wanted to add some properties/columns in IdentityUser class so we created a new UserModel class (inherited from IdentityUser class) to add further properties/columns. 
    // And since now we have a new class for User instead of default IdentityUser class so we have to provide that new class in IdentityDbContext<>.

    public class BookStoreContext : IdentityDbContext<UserModel>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) // passing the settings to the base class constructor
        {

        }

        public DbSet<Book> Books { get; set; } // will create a table in a database with name 'Books'
        public DbSet<BookDuplicate> BookDuplicates { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorAddress> AuthorsAddress { get; set; }
    }
}
