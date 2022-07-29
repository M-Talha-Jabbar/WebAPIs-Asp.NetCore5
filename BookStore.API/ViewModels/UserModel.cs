using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Models
{
    public class UserModel : IdentityUser // Inheriting from IdentityUser class b/c it already have some properties/columns.
    {
        // Adding further properties/columns
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
