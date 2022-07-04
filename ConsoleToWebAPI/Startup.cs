using ConsoleToWebAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        // Before using any service in asp.net core apps we have to inject it in the app first. And the place to inject the services is ConfigureServices method.
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllers(); // now this application has the support of controllers (injecting Web API service).
            services.AddTransient<CustomMiddleware>(); // injecting CustomMiddleware Service.

            // registering a singleton service
            services.TryAddSingleton<IProductRepository, ProductRepository>(); // (service type, implementation of the service to be used)

            //services.AddSingleton<IProductRepository, TestRepository>(); // overriding the implementation of IProductRepository
            services.TryAddSingleton<IProductRepository, TestRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*
            app.Use(async (context, next) => 
            {
                await context.Response.WriteAsync("Hello from Use-1 1 \n");
                
                await next();

                await context.Response.WriteAsync("Hello from Use-1 2 \n");
            });

            // using CustomMiddleware Service
            app.UseMiddleware<CustomMiddleware>();

            app.Map("/talha", CustomCode);

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Use-2 1 \n");

                await next();

                await context.Response.WriteAsync("Hello from Use-2 2 \n");
            });*/

            /*
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from Run \n");
            });
            */
            /*app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Run \n");
            });*/ // You can use Use() without Next(), in place of Run().
            
            app.UseRouting(); // enabling routing in this application

            app.UseEndpoints(endpoints => 
            {
                /*
                endpoints.MapGet("/", async context => 
                {
                    await context.Response.WriteAsync("Hello from new Web API App");
                });

                endpoints.MapGet("/test", async context =>
                {
                    await context.Response.WriteAsync("Hello from new Web API App test");
                });
                */
                // After adding services.AddControllers() in ConfigureServices method we are dealing with controllers so output should be generated from controllers classes.
                // So:
                endpoints.MapControllers(); // mapping routes/URL to the controllers.
            });
        }

        private void CustomCode(IApplicationBuilder app)
        {
            //throw new NotImplementedException();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from Talha \n");

                // await next(); // This will call the next middleware in this CustomCode function only, will not call the middleware outside this function.
            });
        }
    }
}
