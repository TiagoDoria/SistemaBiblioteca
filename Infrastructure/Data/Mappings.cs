using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Data
{
    public class Mappings
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AutorDTO, AutorEntity>().ReverseMap();
                config.CreateMap<LivroDTO, LivroEntity>().ReverseMap();
                config.CreateMap<GeneroDTO, GeneroEntity>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
