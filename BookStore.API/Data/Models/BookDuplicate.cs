namespace BookStore.API.Data.Models
{
    public class BookDuplicate
    {
        public int Id { get; set; } // this will be autoincremented by default. 
        public int CopyNumber { get; set; }


        // for 1:N relationship between Book : BookDuplicate
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
