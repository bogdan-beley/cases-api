using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Services
{
    public class IncidentService : IIncidentService
    {
        public async Task<Incident> GetIncidentByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Incident>> GetIncidentsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Incident> PostIncidentAsync(Incident incident)
        {
            throw new NotImplementedException();
        }
    }
}
