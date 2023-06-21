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
        [HttpGet]
        public IActionResult Login(string username,string password) {
            var account=_accountRepository.Login(username, password);
            return Ok(account);
        
        }
    }
}
