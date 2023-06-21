using Application.Services.AccountService;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.DataTransferObject.Parameter;
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
        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpParam model) {
            var account=await _accountService.SignUpAsync(model);
            return Ok(account);    
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInParam model)
        {
            var account = await _accountService.SignInAsync(model);
            return Ok(account);
        }

        [HttpGet("ByEmail")]
        [Authorize]
        public async Task<ActionResult> GetByEmail(string email)
        {
            var account= await _accountService.GetAccountsByEmail(email);
            return Ok(account);
        }
    }
}
