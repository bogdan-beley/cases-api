using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Data
{
    public interface IAccountRepo
    {
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(int id);
        Task<Account> PostAccountAsync(Account account);
    }
}
