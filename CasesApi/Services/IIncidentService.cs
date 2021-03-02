using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Services
{
    public interface IIncidentService
    {
        Task<IEnumerable<Incident>> GetIncidentsAsync();
        Task<Incident> GetIncidentByNameAsync(string name);
    }
}
