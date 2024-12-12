using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILivroRepository : IRepositoryBase<LivroEntity>
    {
        Task<IEnumerable<LivroEntity>> GetAllLivrosAsync();

    }
}
