using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace BigOn.Domain.AppCode.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";
                var errorsJson = JsonConvert.SerializeObject(ex.Errors);

                await context.Response.WriteAsync(errorsJson);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

                //log to db

                await context.Response.WriteAsync("Gozlenilmez xeta bash verdi biraz sonra yeniden yoxlayin");
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IServiceCollection AddErrorHandler(this IServiceCollection services)
        {
            services.AddSingleton<ExceptionHandlerMiddleware>();

            return services;
        }

        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            return app;
        }
    }
}
