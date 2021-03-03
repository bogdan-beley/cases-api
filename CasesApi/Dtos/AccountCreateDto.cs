using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasesApi.Dtos
{
    public class AccountCreateDto
    {
        [Required(ErrorMessage = "'Name' is required")]
        public string Name { get; set; }

        [ForeignKey("FK_Accounts_Incidents_IncidentName")]
        public string IncidentName { get; set; }
    }
}
