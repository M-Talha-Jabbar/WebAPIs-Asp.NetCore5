using BookStore.API.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Data
{
    public class Author
    {
        public int Id { get; set; } // this will be autoincremented by default. 
        public string Name { get; set; }


        // for 1:1 relationship between Author : AuthorAddress
        public int AuthorAddressId { get; set; }
        public AuthorAddress AuthorAddress { get; set; }


        // for N:N relationship between Book : Author
        public List<Book> Books { get; set; } // This 'Author' Model is independent from 'Author' ViewModel so creating another relationship in it will not affect my API response.
    }
}
