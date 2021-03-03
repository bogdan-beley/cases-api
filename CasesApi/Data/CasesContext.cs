using CasesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CasesApi.Data
{
    public class CasesContext : DbContext
    {
        public CasesContext(DbContextOptions<CasesContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Incident> Incidents { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Name).IsUnique();
            modelBuilder.Entity<Contact>()
                .HasIndex(c => c.Email).IsUnique();
        }
    }
}
