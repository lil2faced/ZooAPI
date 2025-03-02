


using System.Net;
using System.Text.Json;

namespace ZooAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 501;
                await context.Response.WriteAsync(ex.Message);
            }
        }
    }
}
