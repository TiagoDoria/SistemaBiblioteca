using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Infrastructure.Data
{
    public class Mappings
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<AutorDTO, AutorEntity>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.Value))
                    .ForMember(dest => dest.Nascimento, opt => opt.MapFrom(src => src.Nascimento.Value));

                // Mapeamento reverso: De AutorEntity para AutorDTO no GET
                config.CreateMap<AutorEntity, AutorDTO>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => new NomeVO(src.Nome)))
                    .ForMember(dest => dest.Nascimento, opt => opt.MapFrom(src => new DataNascimentoVO(src.Nascimento)));

                //        ----------------------------------------------------------------------------------------------------------------------------

                config.CreateMap<LivroDTO, LivroEntity>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.Value))
                    .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DataLancamento.Value));

                // Mapeamento reverso: De AutorEntity para AutorDTO no GET
                config.CreateMap<LivroEntity, LivroDTO>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => new NomeVO(src.Nome)))
                    .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => new DataNascimentoVO(src.DataLancamento)));

                //        ----------------------------------------------------------------------------------------------------------------------------


                config.CreateMap<GeneroDTO, GeneroEntity>().ReverseMap();
                config.CreateMap<GeneroDTO, GeneroEntity>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.Value));

                config.CreateMap<GeneroEntity, GeneroDTO>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => new NomeVO(src.Nome)));


            });
            return mappingConfig;
        }
    }
}
