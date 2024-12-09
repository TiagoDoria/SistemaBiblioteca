using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Net;

namespace SistemaBiblioteca.Controllers
{
    /*
     Centralizando lógica comum entre as controllers do projeto, com tratamento de erro e resposta padrão
     */
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult<RespostaDTO> CreateResponse(object? result, string message, bool success, HttpStatusCode statusCode)
        {
            var response = new RespostaDTO
            {
                Result = result,
                Message = message,
                IsSuccess = success,
                StatusCode = statusCode
            };

            return StatusCode((int)statusCode, response);
        }

        protected ActionResult<RespostaDTO> HandleError(Exception ex, string actionName)
        {
            Log.Error(ex, $"Erro na ação {actionName}: {ex.Message}");
            return CreateResponse(null, "Ocorreu um erro ao processar a solicitação.", false, HttpStatusCode.InternalServerError);
        }
    }
}
