using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasesApi.Dtos
{
    public class AccountCreateDto
    {
        [Required(ErrorMessage = "'Name' is required")]
        public string Name { get; set; }

        public ICollection<ContactCreateDto> Contacts { get; set; }
    }
}
