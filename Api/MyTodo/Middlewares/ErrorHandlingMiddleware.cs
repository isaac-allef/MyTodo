using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MyTodo.Models;

namespace MyTodo.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ApplicationExceptionStatusCode err)
            {
                await HandleExceptionAsync(httpContext, err.StatusCode, err);
            }
            catch (Exception err)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, err);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, Exception error)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(new {
                message = error.Message,
                traceId = context.TraceIdentifier
            }));
        }
    }
}