using Application.DTOs;
using Application.Features.Autor.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Autor.Handlers
{
    public class AtualizarAutorCommandHandler : IRequestHandler<AtualizarAutorCommand, AutorDTO>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public AtualizarAutorCommandHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<AutorDTO> Handle(AtualizarAutorCommand request, CancellationToken cancellationToken)
        {
            var autor = _mapper.Map<AutorEntity>(request.Autor);

            await _autorRepository.Update(autor);

            return _mapper.Map<AutorDTO>(autor);
        }
    }
}
