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
            if (incident == null)
                throw new ArgumentNullException(nameof(incident));

            var account = incident.Accounts.First();
            var contact = incident.Accounts.First().Contacts.First();
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Name == account.Name);
            
            if (existingAccount == null)
                throw new ArgumentException($"The specified account '{account.Name}' is not found in the database.");

            var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);

            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;

                if (existingContact.AccountId == null)
                    existingContact.AccountId = existingAccount.Id;
            }
            else
            {
                contact.AccountId = existingAccount.Id;
                await _context.Contacts.AddAsync(contact);
            }
            
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
