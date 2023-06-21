using Domain.Models;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository :IAccountRepository
    {
        private readonly DemoLoginContext _context;
        public AccountRepository(DemoLoginContext context) {
         _context = context;
        }

        public Account Login(string username, string password)
        {
            var account = _context.Accounts.FirstOrDefault(a=>a.Username == username&&a.Password == password);
            return account;
        }
    }
}
