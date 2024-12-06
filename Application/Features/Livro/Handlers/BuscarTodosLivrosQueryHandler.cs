using Application.DTOs;
using Application.Features.Livro.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Livro.Handlers
{
    public class BuscarTodosLivrosQueryHandler : IRequestHandler<BuscarTodosLivrosQuery, IEnumerable<LivroDTO>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;
        public BuscarTodosLivrosQueryHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LivroDTO>> Handle(BuscarTodosLivrosQuery request, CancellationToken cancellationToken)
        {
            var autores = await _livroRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<LivroDTO>>(autores);
        }
    }
}
