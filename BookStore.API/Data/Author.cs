namespace BookStore.API.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Books Books { get; set; }
    }
}
