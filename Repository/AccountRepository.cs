using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.DataTransferObject.Parameter;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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

        public Account GetAccountsByEmail(string email)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Email.Equals(email));
            return account;
        }

        public async Task<string> SignInAsync(SignInParam model)
        {
            var result = await signInManager.PasswordSignInAsync
                (model.Username, model.Password, false, false);
            if (!result.Succeeded)
            {
                return string.Empty;
            }
            var user = await userManager.FindByNameAsync(model.Username);
            //var role = user.Role;
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                //new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(5),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpParam model)
        {
            var account = new Account
            {
                UserName = model.Username,
                Email = model.Email
            };
            return await userManager.CreateAsync(account, model.Password);
        }
    }
}
