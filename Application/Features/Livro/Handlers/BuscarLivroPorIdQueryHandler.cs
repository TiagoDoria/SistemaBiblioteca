using Application.DTOs;
using Application.Features.Livro.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Livro.Handlers
{
    public class BuscarLivroPorIdQueryHandler : IRequestHandler<BuscarLivroPorIdQuery, LivroDTO>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;
        public BuscarLivroPorIdQueryHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<LivroDTO> Handle(BuscarLivroPorIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var livro = await _livroRepository.GetByIdAsync(request.Id);

                if (livro == null)
                {
                    return null;
                }

                return _mapper.Map<LivroDTO>(livro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
