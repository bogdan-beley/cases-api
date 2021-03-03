using CasesApi.Data;
using CasesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;

        public AccountsController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.GetAllAccountsAsync();

            if (!accounts.Any())
            {
                return NotFound("Sorry, the list of accounts is empty.");
            }

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound($"Sorry. No account found for the specified id: {id}. ");
            }

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncidentAsync(Account account)
        {
            // if (Model.State is valid)
            await _accountRepo.PostAccountAsync(account);

            return CreatedAtAction(nameof(GetAccountByIdAsync), new { name = account.Id }, account);
        }
    }
}
