using Application.DTOs;
using Application.Features.Autor.Queries;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Linq.Expressions;

namespace Application.Features.Autor.Handlers
{
    public class BuscarAutorQueryHandler : IRequestHandler<BuscarAutorQuery, IEnumerable<AutorDTO>>
    {
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public BuscarAutorQueryHandler(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AutorDTO>> Handle(BuscarAutorQuery request, CancellationToken cancellationToken)
        {
            var autoresPredicate = _mapper.MapExpression<Expression<Func<AutorEntity, bool>>>(request.Predicate);
            var autores = await _autorRepository.FindAsync(autoresPredicate);

            return _mapper.Map<IEnumerable<AutorDTO>>(autores);
        }
    }
}
