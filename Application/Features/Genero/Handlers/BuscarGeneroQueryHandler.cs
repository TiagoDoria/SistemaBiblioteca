using Application.DTOs;
using Application.Features.Genero.Queries;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Genero.Handlers
{
    public class BuscarGeneroQueryHandler : IRequestHandler<BuscarGeneroQuery, IEnumerable<GeneroDTO>>
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;

        public BuscarGeneroQueryHandler(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GeneroDTO>> Handle(BuscarGeneroQuery request, CancellationToken cancellationToken)
        {
            var autoresPredicate = _mapper.MapExpression<Expression<Func<GeneroEntity, bool>>>(request.Predicate);
            var generos = await _generoRepository.FindAsync(autoresPredicate);

            return _mapper.Map<IEnumerable<GeneroDTO>>(generos);
        }
    }
}
