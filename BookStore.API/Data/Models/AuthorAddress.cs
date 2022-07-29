using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Models
{
    public class AuthorAddress
    {
        [Key]
        public int Id { get; set; }
        public string Location { get; set; }


        // for 1:1 relationship between Author : AuthorAddress
        public Author Author { get; set; }
    }
}
