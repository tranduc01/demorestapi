using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;

namespace DemoResfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpPost]
        public async Task<ActionResult> SignUp(SignUp model) {
            var account=await _accountRepository.SignUpAsync(model);
            return Ok(account);
        
        }
    }
}
