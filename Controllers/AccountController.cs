using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBookApi.Models;
using MyBookApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountrepository;

        public AccountController(IAccountRepository _accountrepository)
        {
            accountrepository = _accountrepository;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignUpModel model)
        {
            var result = await accountrepository.signUp(model);
            if(result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();

        }
    }
}
