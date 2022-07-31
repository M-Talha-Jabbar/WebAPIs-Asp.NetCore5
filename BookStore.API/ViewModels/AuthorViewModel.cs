using BookStore.API.Data.Models;

namespace BookStore.API.ViewModels
{
    // AuthorViewModel & AuthorBooksViewModel are used in AuthorController.
    public class AuthorViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int AuthorAddressId { get; set; }
        public AuthorAddress AuthorAddress { get; set; }
    }
}
