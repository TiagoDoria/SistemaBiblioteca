using Application.DTOs;
using Application.Features.Genero.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Genero.Handlers
{
    public class AtualizarGeneroCommandHandler : IRequestHandler<AtualizarGeneroCommand, GeneroDTO>
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public AtualizarGeneroCommandHandler(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task<GeneroDTO> Handle(AtualizarGeneroCommand request, CancellationToken cancellationToken)
        {
            var genero = _mapper.Map<GeneroEntity>(request.Genero);

            await _generoRepository.Update(genero);

            return _mapper.Map<GeneroDTO>(genero);
        }
    }
}
