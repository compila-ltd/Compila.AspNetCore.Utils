using System;
using System.Net;

using Compila.Net.Utils.Rest;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Compila.AspNetCore.Utils.Middlewares
{
    public static class ErrorHandlerMiddleware
    {
        public static void ConfigureErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var error = new ErrorDetails { Message = "Internal Server Error", StatusCode = (int)HttpStatusCode.InternalServerError };

                    var dev = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development" ? true : false;

                    if (contextFeature != null)
                    {

                        switch (contextFeature.Error)
                        {
                            default:
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                                if (dev)
                                    error.Errors.Add($"{contextFeature?.Error.Message}. {(contextFeature?.Error.InnerException != null ? contextFeature?.Error.InnerException.Message : "")}");

                                break;
                        }

                        await context.Response.WriteAsync(error.ToString());
                    }
                });
            });
        }
    }
}
