using Microsoft.AspNetCore.Identity;
using MyBookApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Repository
{
   public interface IAccountRepository
    {
         Task<IdentityResult> signUp(SignUpModel model);
    }
}
