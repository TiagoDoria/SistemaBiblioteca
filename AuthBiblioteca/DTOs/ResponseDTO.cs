using System.Net;

namespace AuthBiblioteca.DTOs
{
    public class RespostaDTO<T>
    {
        /// <summary>
        /// Indica se a operação foi bem-sucedida.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Código de status HTTP associado à resposta.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Mensagem descritiva do resultado da operação.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Resultado da operação, se houver.
        /// </summary>
        public T Result { get; set; }
    }
}
