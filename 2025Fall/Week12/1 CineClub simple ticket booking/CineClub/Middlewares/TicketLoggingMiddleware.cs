using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CineClub.Middlewares
{
    public class TicketLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public TicketLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Only log requests that start with /tickets
            if (context.Request.Path.StartsWithSegments("/tickets", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"[TICKET] {context.Request.Method} {context.Request.Path} at {DateTime.UtcNow:o}");
            }

            await _next(context);
        }
    }
}
