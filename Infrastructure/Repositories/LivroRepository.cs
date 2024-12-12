using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LivroRepository : RepositoryBase<LivroEntity>, ILivroRepository
    {
        public LivroRepository(BibliotecaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LivroEntity>> GetAllLivrosAsync()
        {
            return await _context.Livros
                                 .Include(l => l.AutorLivro) // Inclui a propriedade 'Autores' na consulta
                                 .Include(l => l.Genero)
                                 .ToListAsync();
        }
    }
}
