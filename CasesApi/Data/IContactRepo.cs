using CasesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public interface IContactRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        void PostContactAsync(Contact incident);
    }
}
