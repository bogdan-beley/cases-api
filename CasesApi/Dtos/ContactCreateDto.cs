using System.ComponentModel.DataAnnotations;

namespace CasesApi.Dtos
{
    public class ContactCreateDto
    {
        [EmailAddress]
        [Required(ErrorMessage = "'Email' is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'FirstName' is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "'LastName' is required")]
        public string LastName { get; set; }
    }
}
