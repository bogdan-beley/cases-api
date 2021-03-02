using CasesApi.Models;
using CasesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncidentsAsync()
        {
            var incidents = await _incidentService.GetIncidentsAsync();

            if (incidents == null)
            {
                return NotFound("Sorry, the list of incidents is empty.");
            }

            return Ok(incidents);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetIncidentByNameAsync(string name)
        {
            var incident = await _incidentService.GetIncidentByNameAsync(name);

            if (incident == null)
            {
                return NotFound($"Sorry. No cases were found for the specified name: {name}. ");
            }

            return Ok(incident);
        }

        public async Task<IActionResult> CreateIncidentAsync(Incident incident)
        {
            // if (Model.State is valid)
            await _incidentService.PostIncidentAsync(incident);

            return CreatedAtAction(nameof(GetIncidentByNameAsync), new { name = incident.Name }, incident);
        }
    }
}