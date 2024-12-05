using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Autor
    {
        public int Id { get; set; }
        public NomeVO Nome { get; set; }
        public DataNascimentoVO Nascimento { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
