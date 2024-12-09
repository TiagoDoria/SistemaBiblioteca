using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class LivroDTO
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Data Lançamento é obrigatório.")]
        public DateTime DataLancamento { get; set; }
        [Required(ErrorMessage = "Autor é obrigatório.")]
        public Guid AutorId { get; set; }
        public AutorDTO AutorDto { get; set; }
        [Required(ErrorMessage = "Gênero é obrigatório.")]
        public Guid GeneroId { get; set; }
        public GeneroDTO Genero { get; set; }
    }
}
