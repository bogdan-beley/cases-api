using AutoMapper;
using CasesApi.Data;
using CasesApi.Dtos;
using CasesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentRepo _incidentRepo;
        private readonly IMapper _mapper;

        public IncidentsController(IIncidentRepo incidentRepo, IMapper mapper)
        {
            _incidentRepo = incidentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReadDto>>> GetAllIncidentsAsync()
        {
            var incidents = await _incidentRepo.GetAllIncidentsAsync();

            if (!incidents.Any())
            {
                return NotFound("Sorry, the list of incidents is empty.");
            }

            return Ok(_mapper.Map<IEnumerable<IncidentReadDto>>(incidents));
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IncidentReadDto>> GetIncidentByNameAsync(string name)
        {
            var incident = await _incidentRepo.GetIncidentByNameAsync(name);

            if (incident == null)
            {
                return NotFound($"Sorry. No incident found for the specified name: {name}. ");
            }

            return Ok(_mapper.Map<IncidentReadDto>(incident));
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncidentAsync(Incident incident)
        {
            // if (Model.State is valid)
            await _incidentRepo.PostIncidentAsync(incident);

            return CreatedAtAction(nameof(GetIncidentByNameAsync), new { name = incident.Name }, incident);
        }
    }
}