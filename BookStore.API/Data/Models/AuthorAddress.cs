using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data.Models
{
    public class AuthorAddress
    {
        public int Id { get; set; } // this will be autoincremented by default. 
        public string Location { get; set; }


        // for 1:1 relationship between Author : AuthorAddress
        public Author Author { get; set; }
    }
}
