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
            return controller.StatusCode(statusCode, new { errors = result.Errors });
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
            return controller.StatusCode(statusCode, new { errors = result.Errors });
        }
    }
}
