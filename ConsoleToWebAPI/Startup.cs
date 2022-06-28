using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // now this application has the support of controllers (injecting Web API service).
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            app.UseRouting(); // enabling routing in this application

            app.UseEndpoints(endpoints => 
            {
                /*
                endpoints.MapGet("/", async context => 
                {
                    await context.Response.WriteAsync("Hello from new Web API App");
                });
                */
                // After adding services.AddControllers() in ConfigureServices method we are dealing with controllers so output should be generated from controllers classes.
                // So:
                endpoints.MapControllers();

                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Hello from new Web API App test");
                });
            });
        }
    }
}
