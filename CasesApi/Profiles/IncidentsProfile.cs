using AutoMapper;
using CasesApi.Dtos;
using CasesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasesApi.Profiles
{
    public class IncidentsProfile : Profile
    {
        public IncidentsProfile()
        {
            CreateMap<Incident, IncidentReadDto>();
        }
    }
}
