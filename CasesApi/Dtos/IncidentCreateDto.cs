using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasesApi.Dtos
{
    public class IncidentCreateDto
    {
        [Required(ErrorMessage = "'Description' is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "'Account' is required")]
        public ICollection<AccountCreateDto> Accounts { get; set; }
    }
}
