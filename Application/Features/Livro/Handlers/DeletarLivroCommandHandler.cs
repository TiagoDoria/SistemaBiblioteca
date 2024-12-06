using Application.Features.Livro.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Livro.Handlers
{
    public class DeletarLivroCommandHandler : IRequestHandler<DeletarLivroCommand, bool>
    {
        private readonly ILivroRepository _livroRepository;

        public DeletarLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<bool> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var livro = await _livroRepository.GetByIdAsync(request.Id);

                if (livro == null)
                {
                    return false; // Genero não encontrado
                }

                await _livroRepository.Remove(livro.Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
