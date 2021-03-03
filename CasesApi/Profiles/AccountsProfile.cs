using AutoMapper;
using CasesApi.Dtos;
using CasesApi.Models;

namespace CasesApi.Profiles
{
    public class AccountsProfile : Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountReadDto>();
            CreateMap<AccountCreateDto, Account>();
        }
    }
}
