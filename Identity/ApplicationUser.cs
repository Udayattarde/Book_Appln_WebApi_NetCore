using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
    }
}
