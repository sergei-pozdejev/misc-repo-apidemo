using ProductApiDemo.Exceptions;
using ProductApiDemo.Models;

namespace ProductApiDemo.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var traceId = Guid.NewGuid();

            try
            {
                await _next(context);
            }
            catch (InvalidRequestException ex)
            {
                _logger.Log(LogLevel.Warning, ex, $"TraceID {traceId} {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(ErrorResponse.FromException(traceId, context.Response.StatusCode, ex));
            }
            catch (ItemNotFoundException ex)
            {
                _logger.Log(LogLevel.Warning, ex, $"TraceID {traceId} {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(ErrorResponse.FromException(traceId, context.Response.StatusCode, ex));
            }
            catch (ValidationException ex)
            {
                _logger.Log(LogLevel.Warning, ex, $"TraceID {traceId} {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(ErrorResponse.FromException(traceId, context.Response.StatusCode, ex));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex, $"TraceID {traceId} {ex.Message}");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(ErrorResponse.FromException(traceId, context.Response.StatusCode, "Generic exception", ex));
            }
        }

    }
}
