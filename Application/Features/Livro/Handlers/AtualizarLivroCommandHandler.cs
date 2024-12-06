using Application.DTOs;
using Application.Features.Livro.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Livro.Handlers
{
    public class AtualizarLivroCommandHandler : IRequestHandler<AtualizarLivroCommand, LivroDTO>
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;

        public AtualizarLivroCommandHandler(ILivroRepository livroRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
        }

        public async Task<LivroDTO> Handle(AtualizarLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = _mapper.Map<LivroEntity>(request.Genero);

            await _livroRepository.Update(livro);

            return _mapper.Map<LivroDTO>(livro);
        }
    }
}
