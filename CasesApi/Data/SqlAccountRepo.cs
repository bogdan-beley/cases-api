using CasesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> PostAccountAsync(Account account)
        {
            if (account == null)
                throw new ArgumentNullException(nameof(account));

            bool nameNotUnique = await _context.Accounts.AnyAsync(a => a.Name == account.Name);

            if (nameNotUnique)
                throw new ArgumentException("'Name' must be unique");

            var contact = account.Contacts.First();

            var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);

            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;

                if (existingContact.Account == null)
                    existingContact.AccountId = await _context.Accounts.MaxAsync(a => a.Id) + 1;

                account.Contacts.Clear();
            }

            await _context.Accounts.AddAsync(account);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
