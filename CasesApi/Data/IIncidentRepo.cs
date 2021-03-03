using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public interface IIncidentRepo
    {
        Task<IEnumerable<Incident>> GetAllIncidentsAsync();
        Task<Incident> GetIncidentByNameAsync(string name);
        Task<Incident> PostIncidentAsync(Incident incident);
    }
}
