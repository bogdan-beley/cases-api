using AutoMapper;
using CasesApi.Dtos;
using CasesApi.Models;

namespace CasesApi.Profiles
{
    public class ContactsProfiler : Profile
    {
        public ContactsProfiler()
        {
            CreateMap<Contact, ContactReadDto>();
        }
    }
}
