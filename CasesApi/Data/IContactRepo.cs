using CasesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public interface IContactRepo
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByNameAsync(int id);
        Task<Contact> PostContactAsync(Contact incident);
    }
}
