using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<Account> userManager;
        private readonly SignInManager<Account> signInManager;
        private readonly IConfiguration configuration;
        private readonly DemoLoginContext _context;
        public AccountRepository(UserManager<Account> userManager,
            SignInManager<Account> signInManager, IConfiguration configuration, DemoLoginContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _context = context;
        }

        public Account GetAccountsByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignInAsync(SignIn model)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> SignUpAsync(SignUp model)
        {
            var account = new Account
            {
                UserName = model.Username,
                Email = model.Email
            };
            return await userManager.CreateAsync(account,model.Password);
        }
    }
}
