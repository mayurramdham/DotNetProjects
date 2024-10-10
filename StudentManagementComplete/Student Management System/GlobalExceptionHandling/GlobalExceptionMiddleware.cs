using System.Net;

namespace Student_Management_System.GlobalExceptionHandling
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Continue to the next middleware or handler (e.g., command/query handler)
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");

                // Handle the exception globally, returning a standard error response
                await HandleGlobalExceptionAsync(context, ex);
            }
        }

        private Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "An unexpected error occurred. Please try again later.",
                Detailed = exception.Message // Avoid detailed messages in production
            };

            return context.Response.WriteAsJsonAsync(response);
        }
    }

}
