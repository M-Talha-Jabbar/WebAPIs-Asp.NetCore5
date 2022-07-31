namespace BookStore.API.ViewModels
{
    // BookViewModel & DuplicateBookViewModel are used in BookController.
    public class DuplicateBookViewModel
    {
        public int Id { get; set; }
        public int CopyNumber { get; set; }
        public int BookId { get; set; }
    }
}
