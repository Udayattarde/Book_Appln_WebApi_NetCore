using Microsoft.AspNetCore.Identity;
using MyBookApi.Identity;
using MyBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> signUp(SignUpModel model)
        {
            var user = new ApplicationUser()
            {
                firstName = model.firstName,
                secondName = model.secondName,
                Email = model.Email,
                UserName = model.Email
            };

           return await _userManager.CreateAsync(user, model.password);
        }

    }
}
