using System;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace SV_backend.API.Middleware;

public static class ApiExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {

                    var errorDetalhe = new Domain.Models.ErrorDetalhe
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    };

                    await context.Response.WriteAsync(errorDetalhe.ToString());
                }
            });
        });
    }
}
