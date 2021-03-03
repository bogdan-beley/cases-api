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

            var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);
            var account = await _context.Accounts.FindAsync(contact.AccountId);

            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.AccountId = contact.AccountId;
                existingContact.Account = account;

                if (existingContact.AccountId == null)
                {
                    existingContact.AccountId = contact.AccountId;
                    existingContact.Account = account;
                }
                return false;
            }
            else
            {
                contact.Account = account;
                await _context.Contacts.AddAsync(contact);

                return true;
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
