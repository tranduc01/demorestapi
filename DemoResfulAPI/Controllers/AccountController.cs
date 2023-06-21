using Application.Services.AccountService;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace DemoResfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<ActionResult> SignUp(SignUp model) {
            var account=await _accountService.SignUpAsync(model);
            return Ok(account);
        
        }
    }
}
