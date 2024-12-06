using Application.DTOs;
using Application.Features.Livro.Queries;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Livro.Handlers
{
    public class BuscarLivroQueryHandler : IRequestHandler<BuscarLivroQuery, IEnumerable<LivroDTO>>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public BuscarLivroQueryHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LivroDTO>> Handle(BuscarLivroQuery request, CancellationToken cancellationToken)
        {
            var livrosPredicate = _mapper.MapExpression<Expression<Func<LivroEntity, bool>>>(request.Predicate);
            var generos = await _livroRepository.FindAsync(livrosPredicate);

            return _mapper.Map<IEnumerable<LivroDTO>>(generos);
        }
    }
}
