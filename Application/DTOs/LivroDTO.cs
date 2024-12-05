namespace Application.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public int AutorId { get; set; }
        public AutorDTO Autor { get; set; }
        public int GeneroId { get; set; }
        public GeneroDTO Genero { get; set; }
    }
}
