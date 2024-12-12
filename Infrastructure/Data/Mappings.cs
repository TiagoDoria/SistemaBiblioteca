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
                // Mapeamento AutorDTO <-> AutorEntity
                config.CreateMap<AutorDTO, AutorEntity>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.Value))
                    .ForMember(dest => dest.Nascimento, opt => opt.MapFrom(src => src.Nascimento.Value));

                // Mapeamento reverso: AutorEntity para AutorDTO
                config.CreateMap<AutorEntity, AutorDTO>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => new NomeVO(src.Nome)))
                    .ForMember(dest => dest.Nascimento, opt => opt.MapFrom(src => new DataNascimentoVO(src.Nascimento)));


                // Mapeamento LivroDTO <-> LivroEntity
                config.CreateMap<LivroDTO, LivroEntity>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome.Value))
                    .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DataLancamento.Value))
                    .ForMember(dest => dest.AutorLivro, opt => opt.MapFrom(src => src.AutorLivro))
                    .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero));

                // Mapeamento reverso: LivroEntity para LivroDTO
                config.CreateMap<LivroEntity, LivroDTO>()
                    .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => new NomeVO(src.Nome))) // Converte string para NomeVO
                    .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => new DataLancamentoVO(src.DataLancamento))) // Converte DateTime para DataLancamentoVO
                    .ForMember(dest => dest.AutorLivro, opt => opt.MapFrom(src => src.AutorLivro)); // Inclui autores (supondo que a propriedade existe)

                // Mapeamento de GeneroDTO <-> GeneroEntity
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
