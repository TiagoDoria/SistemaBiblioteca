using System.Net;

namespace Application.DTOs
{
    public class RespostaDTO
    {
        public object? Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";

    }
}
