using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AdedonhaAPI.Extensions
{
    public static class ApiExceptionMiddleware
    {
        /// <summary>
        ///  É a solução de tratamento de exceções mais abrangente, capturando exceções em qualquer lugar no pipeline HTTP da sua aplicação. 
        ///  É essencial para garantir que nenhuma exceção vaze para o cliente sem um tratamento adequado e uma resposta padronizada, 
        ///  mesmo em middlewares anteriores ou falhas de inicialização.
        /// </summary>
        /// <param name="app"></param>
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
                        await context.Response.WriteAsync(new ErrorDetailsOutput()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace,
                        }.ToString());
                    }
                });
            });
        }
    }
}
