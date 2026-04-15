namespace TaskZagEng.Middleware
{
    public class RequestLoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;
            var start = DateTime.Now;  

            Console.WriteLine($"[{start:yyyy-MM-dd HH:mm:ss}] {method} {path} → (processing...)");

            await _next(context);

            var elapsed = (DateTime.Now - start).TotalMilliseconds;
            var statusCode = context.Response.StatusCode;
            var statusText = StatusCodeToText(statusCode);

            Console.WriteLine(
                $"[{start:yyyy-MM-dd HH:mm:ss}] {method} {path} → {statusCode} {statusText}  (took {elapsed:F0}ms)");
        }

        private static string StatusCodeToText(int code) => code switch
        {
            200 => "OK",
            201 => "Created",
            204 => "No Content",
            400 => "Bad Request",
            404 => "Not Found",
            500 => "Internal Server Error",
            _ => string.Empty
        };
    }


    public static class RequestLoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app)
            => app.UseMiddleware<RequestLoggerMiddleware>();
    }
}
