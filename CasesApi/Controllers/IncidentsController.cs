using AutoMapper;
using CasesApi.Data;
using CasesApi.Dtos;
using CasesApi.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{name}", Name = "GetIncidentByNameAsync")]
        public async Task<ActionResult<IncidentReadDto>> GetIncidentByNameAsync(string name)
        {
            var incident = await _incidentRepo.GetIncidentByNameAsync(name);

            if (incident == null)
            {
                return NotFound($"Sorry. No incident found for the specified name: {name}.");
            }

            return Ok(_mapper.Map<IncidentReadDto>(incident));
        }

        [HttpPost]
        public async Task<ActionResult<IncidentCreateDto>> CreateIncidentAsync(IncidentCreateDto incidentCreateDto)
        {
            var incidentModel = _mapper.Map<Incident>(incidentCreateDto);

            await _incidentRepo.PostIncidentAsync(incidentModel);
            await _incidentRepo.SaveChangesAsync();

            var incidentReadDto = _mapper.Map<IncidentReadDto>(incidentModel);

            return CreatedAtRoute(nameof(GetIncidentByNameAsync), new { incidentReadDto.Name }, incidentReadDto);
        }
    }
}