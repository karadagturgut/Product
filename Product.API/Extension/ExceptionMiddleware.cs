using Product.Core.GeneralHelper;
using Product.Entity.DTO;
using Product.Service.Service;
using Serilog;
using System.Net;
using System.Text;

namespace Product.API.Extension
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggingService _logger;
        private readonly bool _isRequestResponseLoggingEnabled = true;

        public ExceptionMiddleware(ILoggingService logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IManualLog manualLog)
        {
            // Middleware is enabled only when the EnableRequestResponseLogging config value is set.
            if (_isRequestResponseLoggingEnabled)
            {
               var request = $"HTTP request information:\n" +
                    $"\tMethod: {httpContext.Request.Method}\n" +
                    $"\tPath: {httpContext.Request.Path}\n" +
                    $"\tQueryString: {httpContext.Request.QueryString}\n" +
                    $"\tHeaders: {FormatHeaders(httpContext.Request.Headers)}\n" +
                    $"\tSchema: {httpContext.Request.Scheme}\n" +
                    $"\tHost: {httpContext.Request.Host}\n" +
                    $"\tBody: {await ReadBodyFromRequest(httpContext.Request)}";

                var requestBody = await ReadBodyFromRequest(httpContext.Request);
                // Temporarily replace the HttpResponseStream, which is a write-only stream, with a MemoryStream to capture it's value in-flight.
                var originalResponseBody = httpContext.Response.Body;
                using var newResponseBody = new MemoryStream();
                httpContext.Response.Body = newResponseBody;

                // Call the next middleware in the pipeline
                await _next(httpContext);

                newResponseBody.Seek(0, SeekOrigin.Begin);
                var responseBodyText = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();

               var response = $"HTTP response information:\n" +
                    $"\tStatusCode: {httpContext.Response.StatusCode}\n" +
                    $"\tContentType: {httpContext.Response.ContentType}\n" +
                    $"\tHeaders: {FormatHeaders(httpContext.Response.Headers)}\n" +
                    $"\tBody: {responseBodyText}";

                _logger.LogError($"Request: \n"+ request + "\n" + "Response: \n" + response, new Exception());

                manualLog.Add( new ManualLogRequestDTO() { MethodName = httpContext.Request.Path,  Request = requestBody , Response = responseBodyText, IP = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString()} );
                newResponseBody.Seek(0, SeekOrigin.Begin);
                await newResponseBody.CopyToAsync(originalResponseBody);
            }
            else
            {
                await _next(httpContext);
            }
        }

        private static string FormatHeaders(IHeaderDictionary headers) => string.Join(", ", headers.Select(kvp => $"{{{kvp.Key}: {string.Join(", ", kvp.Value)}}}"));

        private static async Task<string> ReadBodyFromRequest(HttpRequest request)
        {
            // Ensure the request's body can be read multiple times (for the next middlewares in the pipeline).
            request.EnableBuffering();

            using var streamReader = new StreamReader(request.Body, leaveOpen: true);
            var requestBody = await streamReader.ReadToEndAsync();

            // Reset the request's body stream position for next middleware in the pipeline.
            request.Body.Position = 0;
            return requestBody;
        }

    }

    internal class ErrorResultModel
    {
        public ErrorResultModel()
        {
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }


}
