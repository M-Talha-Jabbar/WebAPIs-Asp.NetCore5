using BookStore.API.Data;
using BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.ViewModels
{
    // AuthorViewModel & AuthorBooksViewModel are used in AuthorController.
    public class AuthorBooksViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookViewModel> Books { get; set; } // Notice that we are using BookViewModel, not Book Model.
    }
}
