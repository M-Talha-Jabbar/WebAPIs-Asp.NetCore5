using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) // passing the settings to the base class constructor
        {
            
        }

        public DbSet<Books> Books { get; set; } // will create a table in a database with name 'Books'
        public DbSet<Author> authors { get; set; }
    }
}
