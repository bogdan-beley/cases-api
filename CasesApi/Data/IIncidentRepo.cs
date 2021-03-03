using CasesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public interface IIncidentRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Incident>> GetAllIncidentsAsync();
        Task<Incident> GetIncidentByNameAsync(string name);
        Task<bool> PostIncidentAsync(Incident incident);
    }
}
