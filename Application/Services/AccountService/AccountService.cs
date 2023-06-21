using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
           
        }
        public async Task<Account> GetAccountsByID(string id)
        {
            var account = _accountRepository.GetAccountsByID(id);

            return account;
        }

        public async Task<string> SignInAsync(SignIn model)
        {
            var result = await _accountRepository.SignInAsync(model);

            return result;
        }

        public async Task<IdentityResult> SignUpAsync(SignUp model)
        {
            var result = await _accountRepository.SignUpAsync(model);
            return result;
        }


    }
}
