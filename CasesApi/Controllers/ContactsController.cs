﻿using AutoMapper;
using CasesApi.Data;
using CasesApi.Dtos;
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
        private readonly IMapper _mapper;

        public ContactsController(IContactRepo contactRepo, IMapper mapper)
        {
            _contactRepo = contactRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAllContactsAsync()
        {
            var contacts = await _contactRepo.GetAllContactsAsync();

            if (!contacts.Any())
            {
                return NotFound("Sorry, the list of contacts is empty.");
            }

            return Ok(_mapper.Map<IEnumerable<ContactReadDto>>(contacts));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ContactReadDto>>> GetContactByIdAsync(int id)
        {
            var contact = await _contactRepo.GetContactByIdAsync(id);

            if (contact == null)
            {
                return NotFound($"Sorry. No contact found for the specified id: {id}.");
            }

            return Ok(_mapper.Map<ContactReadDto>(contact));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncidentAsync(Contact contact)
        {
            // if (Model.State is valid)
            _contactRepo.PostContactAsync(contact);

            return CreatedAtAction(nameof(GetContactByIdAsync), new { name = contact.Id }, contact);
        }
    }
}
