using CasesApi.Data;
using CasesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepo _contactRepo;

        public ContactsController(IContactRepo contactRepo)
        {
            _contactRepo = contactRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContactsAsync()
        {
            var contacts = await _contactRepo.GetAllContactsAsync();

            if (!contacts.Any())
            {
                return NotFound("Sorry, the list of contacts is empty.");
            }

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepo.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound($"Sorry. No contact found for the specified id: {id}. ");
            }

            return Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncidentAsync(Contact contact)
        {
            // if (Model.State is valid)
            await _contactRepo.PostContactAsync(contact);

            return CreatedAtAction(nameof(GetContactByIdAsync), new { name = contact.Id }, contact);
        }
    }
}
