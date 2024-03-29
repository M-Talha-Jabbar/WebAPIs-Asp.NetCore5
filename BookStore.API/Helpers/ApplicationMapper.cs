﻿using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            // CreateMap<Books, BookModel>(); // Creates a mapping configuration from the Books type to the BookModel type.
            // CreateMap<BookModel, Books>(); // Reverse mapping also.

            // OR 

            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
