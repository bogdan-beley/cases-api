using CasesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CasesApi.Data
{
    public class CasesContext : DbContext
    {
        public CasesContext(DbContextOptions<CasesContext> options) : base(options)
        {

        }

        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
