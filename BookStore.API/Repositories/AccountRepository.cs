using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<UserModel> userManager;
        public AccountRepository(UserManager<UserModel> userManager)
        {
            this.userManager = userManager;
            // In BookRepository we were using BookStoreContext to deal with the database.
            // But since here we are dealing with the Identity Core so there is no need to use BookStoreContext directly.
            // We can handle everything by the Managers provided by the Identity Core.
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new UserModel()
            {
                FirstName = signUpModel.FirstName,
                LastName = signUpModel.LastName,
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await userManager.CreateAsync(user, signUpModel.Password);
        }
    }
}
