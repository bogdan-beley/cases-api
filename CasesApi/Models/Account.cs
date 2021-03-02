using System.Collections.Generic;

namespace CasesApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; } // unique

        public string IncidentName { get; set; } // is it necessary?
        public Incident Incident { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
