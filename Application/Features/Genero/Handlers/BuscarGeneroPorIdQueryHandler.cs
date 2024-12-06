using Application.DTOs;
using Application.Features.Genero.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Genero.Handlers
{
    public class BuscarGeneroPorIdQueryHandler : IRequestHandler<BuscarGeneroPorIdQuery, GeneroDTO>
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;
        public BuscarGeneroPorIdQueryHandler(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task<GeneroDTO> Handle(BuscarGeneroPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var genero = await _generoRepository.GetByIdAsync(request.Id);

                if (genero == null)
                {
                    return null;
                }

                return _mapper.Map<GeneroDTO>(genero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
