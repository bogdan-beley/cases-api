using AutoMapper;
using CasesApi.Dtos;
using CasesApi.Models;

namespace CasesApi.Profiles
{
    public class IncidentsProfile : Profile
    {
        public IncidentsProfile()
        {
            CreateMap<Incident, IncidentReadDto>();
            CreateMap<IncidentCreateDto, Incident>();
        }
    }
}
