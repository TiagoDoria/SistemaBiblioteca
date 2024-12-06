using Domain.ValueObjects;

namespace Domain.Entities
{
    public class GeneroEntity
    {
        public Guid Id { get; private set; }
        public NomeVO Nome { get; private set; }
        public ICollection<LivroEntity> Livros { get; private set; }
    }
}
