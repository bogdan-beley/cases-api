using System.ComponentModel.DataAnnotations;

namespace CasesApi.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; } // unique identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
