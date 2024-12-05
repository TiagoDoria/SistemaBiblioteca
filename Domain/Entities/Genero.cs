using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Genero
    {
        public int Id { get; private set; }
        public NomeVO Nome { get; private set; }
        public ICollection<Livro> Livros { get; private set; }
    }
}
