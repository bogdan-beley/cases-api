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
            // Get all the specified accounts if they already exist in the database
            var existingAccounts = await _context.Accounts
                .Where(a => incident.Accounts.Select(x => x.Name).Contains(a.Name)).ToListAsync();

            // Throw an exception if any of the specified accounts are not in the database
            if (incident.Accounts.Count != existingAccounts.Count)
                throw new ArgumentException("Can`t find specified account(s) in the database");

            // Add or update contacts and link them to existing Account
            foreach (var account in incident.Accounts)
            {
                // Check if the specified contact already exists in the database
                foreach (var contact in account.Contacts)
                {
                    var existingContact = await _context.Contacts.FirstOrDefaultAsync(c => c.Email == contact.Email);
                    // Update the contact if exists
                    if (existingContact != null)
                    {
                        existingContact.FirstName = contact.FirstName;
                        existingContact.LastName = contact.LastName;
                        existingContact.AccountId = existingAccounts.First(e => e.Name == account.Name).Id;
                    }
                    // Add a new contact if not exists
                    else
                    {
                        contact.AccountId = existingAccounts.First(e => e.Name == account.Name).Id;
                        await _context.Contacts.AddAsync(contact);
                    }
                }
            }

            // Link existing accounts to Incident model
            incident.Accounts = existingAccounts;

            // Add incident to database context
            await _context.Incidents.AddAsync(incident);

            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
