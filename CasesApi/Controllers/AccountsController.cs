using CasesApi.Data;
using CasesApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CasesApi.Dtos;
using System.Collections.Generic;

namespace CasesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepo _accountRepo;
        private readonly IMapper _mapper;

        public AccountsController(IAccountRepo accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountReadDto>>> GetAllAccountsAsync()
        {
            var accounts = await _accountRepo.GetAllAccountsAsync();

            if (!accounts.Any())
            {
                return NotFound("Sorry, the list of accounts is empty.");
            }

            return Ok(_mapper.Map<IEnumerable<AccountReadDto>>(accounts));
        }

        [HttpGet("{id}", Name = "GetAccountByIdAsync")]
        public async Task<ActionResult<AccountReadDto>> GetAccountByIdAsync(int id)
        {
            var account = await _accountRepo.GetAccountByIdAsync(id);

            if (account == null)
            {
                return NotFound($"Sorry. No account found for the specified id: {id}. ");
            }

            return Ok(_mapper.Map<AccountReadDto>(account));
        }

        [HttpPost]
        public async Task<ActionResult<AccountCreateDto>> CreateAccountAsync(AccountCreateDto accountCreateDto)
        {
            var accountModel = _mapper.Map<Account>(accountCreateDto);

            await _accountRepo.PostAccountAsync(accountModel);
            await _accountRepo.SaveChangesAsync();

            var accountReadDto = _mapper.Map<AccountReadDto>(accountModel);

            return CreatedAtRoute(nameof(GetAccountByIdAsync), new { accountReadDto.Id }, accountReadDto);
        }
    }
}
