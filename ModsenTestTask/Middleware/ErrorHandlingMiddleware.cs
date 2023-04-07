using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            var statusCode = GetStatusCode(ex);
            var result = JsonSerializer.Serialize(new { error = ex.Message });

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            return httpContext.Response.WriteAsync(result);
        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                ArgumentNullException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };

    }

}
