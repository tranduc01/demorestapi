
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Repository.DataTransferObject.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AccountService
{
    public interface IAccountService
    {
        public Task<IdentityResult> SignUpAsync(SignUpParam model);
        public Task<string> SignInAsync(SignInParam model);
        public Task<Account> GetAccountsByEmail(string email);
    }
}
