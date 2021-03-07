using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
