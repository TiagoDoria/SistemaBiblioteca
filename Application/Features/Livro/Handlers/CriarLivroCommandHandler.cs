using Application.DTOs;
using Application.Features.Livro.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Livro.Handlers
{
    public class CriarLivroCommandHandler : IRequestHandler<CriarLivroCommand, LivroDTO>
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public CriarLivroCommandHandler(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LivroDTO> Handle(CriarLivroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var livroDto = request.Livro;

                var livro = _mapper.Map<LivroEntity>(livroDto);

                await _repository.AddAsync(livro);

                return _mapper.Map<LivroDTO>(livro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
