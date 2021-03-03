using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Dtos
{
    public class AccountReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IncidentName { get; set; }
    }
}
