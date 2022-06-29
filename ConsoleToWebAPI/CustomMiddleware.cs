using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //throw new System.NotImplementedException();
            await context.Response.WriteAsync("Hello fromn Custom Middleware \n");

            await next(context); // If you are using a separate/custom file then you need to pass the "context".

            await context.Response.WriteAsync("Hello from Custom Middleware \n");
        }
    }
}
