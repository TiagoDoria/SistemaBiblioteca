using Application.DTOs;
using Application.Features.Genero.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Genero.Handlers
{
    public class BuscarTodosGenerosQueryHandler : IRequestHandler<BuscarTodosGenerosQuery, IEnumerable<GeneroDTO>>
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;
        public BuscarTodosGenerosQueryHandler(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GeneroDTO>> Handle(BuscarTodosGenerosQuery request, CancellationToken cancellationToken)
        {
            var autores = await _generoRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GeneroDTO>>(autores);
        }
    }
}
