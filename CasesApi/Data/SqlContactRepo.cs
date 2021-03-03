using CasesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public class SqlContactRepo : IContactRepo
    {
        private readonly CasesContext _context;

        public SqlContactRepo(CasesContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> PostContactAsync(Contact contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            bool emailNotUnique = await _context.Contacts.AnyAsync(c => c.Email == contact.Email);

            if (emailNotUnique)
                throw new ArgumentException("'Email' must be unique");
            
            if (contact.AccountId != null)
            {
                var account = await _context.Accounts.FindAsync(contact.AccountId);

                if (account == null)
                    throw new ArgumentException($"The specified account id '{contact.AccountId}' is not found in the database.");

                contact.Account = account;
            }
            
            await _context.Contacts.AddAsync(contact);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
