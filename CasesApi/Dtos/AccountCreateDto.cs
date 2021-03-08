using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasesApi.Dtos
{
    public class AccountCreateDto
    {
        [Required(ErrorMessage = "'Name' is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'Contact' is required")]
        public ICollection<ContactCreateDto> Contacts { get; set; }
    }
}
