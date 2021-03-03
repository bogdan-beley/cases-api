using AutoMapper;
using CasesApi.Dtos;
using CasesApi.Models;

namespace CasesApi.Profiles
{
    public class ContactsProfile : Profile
    {
        public ContactsProfile()
        {
            CreateMap<Contact, ContactReadDto>();
            CreateMap<ContactCreateDto, Contact>();
        }
    }
}
