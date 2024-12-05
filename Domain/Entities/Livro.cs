using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Livro
    {
        public int Id { get; set; }
        public NomeVO Nome { get; set; }
        public DataLancamentoVO DataLancamento { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int GeneroId { get; set; }
        public Genero Genero { get; set; }
    }
}
