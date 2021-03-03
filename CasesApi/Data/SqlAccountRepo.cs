using CasesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public class SqlAccountRepo : IAccountRepo
    {
        private readonly CasesContext _context;

        public SqlAccountRepo(CasesContext context)
        {
            _context = context;
        }
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> PostAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
