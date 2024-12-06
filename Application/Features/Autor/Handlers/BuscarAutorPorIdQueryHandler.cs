using Application.DTOs;
using Application.Features.Autor.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Autor.Handlers
{
    public class BuscarAutorPorIdQueryHandler : IRequestHandler<BuscarAutorPorIdQuery, AutorDTO>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;
        public BuscarAutorPorIdQueryHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<AutorDTO> Handle(BuscarAutorPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var autor = await _autorRepository.GetByIdAsync(request.Id);

                if (autor == null)
                {
                    return null;
                }

                return _mapper.Map<AutorDTO>(autor);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
