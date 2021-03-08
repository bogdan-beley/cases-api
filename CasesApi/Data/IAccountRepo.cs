using CasesApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public interface IAccountRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task<bool> PostAccountAsync(Account account);
    }
}
