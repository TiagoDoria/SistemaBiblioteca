using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class GeneroDTO
    {
        public Guid Id { get; private set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public NomeVO Nome { get; set; }
        public ICollection<LivroDTO>? Livros { get; set; }
    }
}
