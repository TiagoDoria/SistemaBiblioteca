using Application.DTOs;
using Application.Features.Autor.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Autor.Handlers
{
    public class BuscarTodosAutoresQueryHandler : IRequestHandler<BuscarTodosAutoresQuery, IEnumerable<AutorDTO>>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;
        public BuscarTodosAutoresQueryHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AutorDTO>> Handle(BuscarTodosAutoresQuery request, CancellationToken cancellationToken)
        {
            var autores = await _autorRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AutorDTO>>(autores);
        }
    }
}
