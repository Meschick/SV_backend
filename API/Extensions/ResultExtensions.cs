using Microsoft.AspNetCore.Mvc;
using SV_backend.Application.Results;

namespace SV_backend.API.Extensions
{
    public static class ResultExtensions
    {
        public static IActionResult ToActionResult(this Result result, ControllerBase controller)
        {
            if (result.IsSuccess)
            {
                var status = result.StatusCode ?? 200;
                return controller.StatusCode(status);
            }

            var statusCode = result.StatusCode ?? 400;
            return CreateProblemDetails(controller, statusCode, result.Errors);
        }

        public static IActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
        {
            if (result.IsSuccess)
            {
                var status = result.StatusCode ?? 200;
                if (status == 201)
                {
                    return controller.Created(string.Empty, result.Value);
                }

                return new ObjectResult(result.Value) { StatusCode = status };
            }

            var statusCode = result.StatusCode ?? 400;
            return CreateProblemDetails(controller, statusCode, result.Errors);
        }

        private static IActionResult CreateProblemDetails(
            ControllerBase controller,
            int statusCode,
            IEnumerable<string>? errors)
        {
            var errorMessages = errors?.ToArray() ?? Array.Empty<string>();
            var title = statusCode switch
            {
                400 => "Requisição inválida",
                401 => "Não autenticado",
                403 => "Acesso negado",
                404 => "Recurso não encontrado",
                409 => "Conflito",
                >= 500 => "Erro no servidor",
                _ => "Falha na solicitação"
            };

            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = errorMessages.Length > 0 ? string.Join(" ", errorMessages) : title,
                Instance = controller.HttpContext.Request.Path
            };

            if (errorMessages.Length > 0)
                problem.Extensions["errors"] = errorMessages;

            return new ObjectResult(problem)
            {
                StatusCode = statusCode,
                ContentTypes = { "application/problem+json" }
            };
        }
    }
}
