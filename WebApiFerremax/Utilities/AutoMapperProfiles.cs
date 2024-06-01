using AutoMapper;
using WebApiFerremax.DTOs;
using WebApiFerremax.Entities;

namespace WebApiFerremax.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<HerramientaCreacionDTO, Herramienta>(); 
            CreateMap<Herramienta, HerramientaDTO>();
            CreateMap<HerramientaManualCreacionDTO, HerramientaManual>();
            CreateMap<HerramientaManual, HerramientaManualDTO>();
        }
    }
}
