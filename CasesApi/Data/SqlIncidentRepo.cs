using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public class SqlIncidentRepo : IIncidentRepo
    {
        public async Task<Incident> GetIncidentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Incident>> GetAllIncidentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Incident> PostIncidentAsync(Incident incident)
        {
            throw new NotImplementedException();
        }
    }
}
