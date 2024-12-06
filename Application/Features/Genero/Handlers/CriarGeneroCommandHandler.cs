using Application.DTOs;
using Application.Features.Genero.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Genero.Handlers
{
    public class CriarGeneroCommandHandler : IRequestHandler<CriarGeneroCommand, GeneroDTO>
    {
        private readonly IGeneroRepository _repository;
        private readonly IMapper _mapper;

        public CriarGeneroCommandHandler(IGeneroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GeneroDTO> Handle(CriarGeneroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var generoDto = request.Genero;

                var genero = _mapper.Map<GeneroEntity>(generoDto);

                await _repository.AddAsync(genero);

                return _mapper.Map<GeneroDTO>(genero);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
