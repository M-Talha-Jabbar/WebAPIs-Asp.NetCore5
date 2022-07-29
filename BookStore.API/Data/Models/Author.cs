using BookStore.API.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Data
{
    public class Author
    {
        [Key]
        public int Id { get; set; } // this will be autoincremented by default. 
        public string Name { get; set; }


        // for 1:1 relationship between Author : AuthorAddress
        [ForeignKey(nameof(AuthorAddress))]
        public int AuthorAddressId { get; set; }
        public AuthorAddress AuthorAddress { get; set; }
    }
}
