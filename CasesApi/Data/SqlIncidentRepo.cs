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

        public async Task<Incident> PostIncidentAsync(Incident incident)
        {
            throw new NotImplementedException();
        }
    }
}
