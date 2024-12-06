using Domain.ValueObjects;

namespace Domain.Entities
{
    public class AutorEntity
    {
        public Guid Id { get; set; }
        public NomeVO Nome { get; set; }
        public DataNascimentoVO Nascimento { get; set; }
        public ICollection<LivroEntity> Livros { get; set; }
    }
}
