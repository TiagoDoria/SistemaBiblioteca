using Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class AutorDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public NomeVO Nome { get; set; }
        [Required(ErrorMessage = "Data Nascimento é obrigatório.")]
        public DataNascimentoVO Nascimento { get; set; }
    }
}
