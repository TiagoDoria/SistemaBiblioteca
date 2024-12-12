using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class LivroEntity
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public Guid AutorId { get; set; }
        public AutorEntity? AutorLivro { get; set; }
        [Required]
        public Guid GeneroId { get; set; }
        public GeneroEntity? Genero { get; set; }
    }
}
