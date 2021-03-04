using CasesApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public class SqlIncidentRepo : IIncidentRepo
    {
        private readonly CasesContext _context;

        public SqlIncidentRepo(CasesContext context)
        {
            _context = context;
        }

        public async Task<Incident> GetIncidentByNameAsync(string name)
        {
            return await _context.Incidents.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            return await _context.Incidents.ToListAsync();
        }

        public async Task<bool> PostIncidentAsync(Incident incident)
        {
            // check if incident isn`t null
            if (incident == null)
                throw new ArgumentNullException(nameof(incident));

            // get account model from incident model
            var account = incident.Accounts.First();
            // get contact model from incident model
            var contact = incident.Accounts.First().Contacts.First();
            // check if account with specified name exists in database
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Name == account.Name);
            
            // if account with specified name does not exist throw exception
            if (existingAccount == null)
                throw new ArgumentException($"The specified account '{account.Name}' is not found in the database.");

            // check if contact with specified email exists in database
            var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);

            // if contact exists update first and last name
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;

                // link contact record to account if not
                if (existingContact.AccountId == null)
                    existingContact.AccountId = existingAccount.Id;
            }
            // if contact does not exist in database link to account and add to database
            else
            {
                contact.AccountId = existingAccount.Id;
                await _context.Contacts.AddAsync(contact);
            }
            
            // clear incident accounts before adding to context (because we account is already in database)
            incident.Accounts.Clear();
            await _context.Incidents.AddAsync(incident);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
