using Domain.ValueObjects;

namespace Domain.Entities
{
    public class LivroEntity
    {
        public Guid Id { get; set; }
        public NomeVO Nome { get; set; }
        public DataLancamentoVO DataLancamento { get; set; }
        public int AutorId { get; set; }
        public AutorEntity AutorLivro { get; set; }
        public int GeneroId { get; set; }
        public GeneroEntity Genero { get; set; }
    }
}
