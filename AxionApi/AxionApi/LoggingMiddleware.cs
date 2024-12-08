using Serilog;

namespace AxionApi
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Obtener el encabezado de origen
            var origin = context.Request.Headers["Origin"].ToString();

            // Aquí puedes loguear el valor de origin
            Log.Information("Request origin: {Origin}", origin);

            await _next(context);
        }
    }

}
