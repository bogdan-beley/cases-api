using CasesApi.Data;
using CasesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentRepo _incidentRepo;

        public IncidentsController(IIncidentRepo incidentRepo)
        {
            _incidentRepo = incidentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncidentsAsync()
        {
            var incidents = await _incidentRepo.GetAllIncidentsAsync();

            if (!incidents.Any())
            {
                return NotFound("Sorry, the list of incidents is empty.");
            }

            return Ok(incidents);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetIncidentByNameAsync(string name)
        {
            var incident = await _incidentRepo.GetIncidentByNameAsync(name);

            if (incident == null)
            {
                return NotFound($"Sorry. No incident found for the specified name: {name}. ");
            }

            return Ok(incident);
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