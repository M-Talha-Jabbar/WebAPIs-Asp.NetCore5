﻿using BookStore.API.Data.Models;
using System.Collections.Generic;

namespace BookStore.API.Data
{
    public class Book // class for a 'Books' table
    {
        public int Id { get; set; } // this will be autoincremented by default. 
        public string Title { get; set; }   
        public string Description { get; set; }


        // for 1:N relationship between Book : BookDuplicate
        public List<BookDuplicate> BookDuplicate { get; set; }


        // for N:N relationship between Book : Author
        public List<Author> Authors { get; set; } // This 'Book' Model is independent from 'Book' ViewModel so creating another relationship in it will not affect my API response.
    }
}
