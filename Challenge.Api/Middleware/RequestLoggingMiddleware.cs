using System.Diagnostics;

namespace Challenge.Api.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<RequestLoggingMiddleware> _logger;

		public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var stopwatch = Stopwatch.StartNew();

			// Procesar la solicitud
			await _next(context);

			stopwatch.Stop();

			var logMessage = $"Request: {context.Request.Method} {context.Request.Path} responded in {stopwatch.ElapsedMilliseconds}ms";
			_logger.LogInformation(logMessage);
		}
	}
}
