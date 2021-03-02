using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasesApi.Models
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Name { get; set; }

        [Required(ErrorMessage = "'Description' is required")]
        public string Description { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
