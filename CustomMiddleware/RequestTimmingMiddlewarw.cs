using System.Diagnostics;

namespace MVC_01.CustomMiddleware
{
    public class RequestTimmingMiddlewarw
    {
        private RequestDelegate _next;

        public RequestTimmingMiddlewarw(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next.Invoke(context);
            watch.Stop();
            Console.WriteLine($"{context.Request.Path}-{watch.ElapsedMilliseconds}ms");
        }
    }
}
