using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MasWeb2
{
    public class Startup
    {
        private IConfiguration _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
        }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions()
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                //throw new Exception("Some error processing the request");
                await context.Response.WriteAsync("Hello World3 >");

            });

            //FileServerOptions defaultFileServerOptions=new FileServerOptions();
            //defaultFileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //defaultFileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseFileServer(defaultFileServerOptions);
            ////app.UseDefaultFiles(defaultFilesOptions);
            ////app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Si se ve este mensaje es porque se esta accediendo a la direccion equivacada");
            //});
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1: Incomming Request");
            //    await next();
            //    logger.LogInformation("MW1: Outgoing Response");
            //    await context.Response.WriteAsync(Process.GetCurrentProcess().ProcessName);
            //    //await context.Response.WriteAsync("Hola Mundo");
            //    //await context.Response.WriteAsync(_config["MyKey"]); //lee el valor de appsettings.json

            //});


            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2: Incomming Request");
            //    await next();
            //    logger.LogInformation("MW2: Outgoing Response");
            //    await context.Response.WriteAsync(Process.GetCurrentProcess().ProcessName);
            //    //await context.Response.WriteAsync("Hola Mundo");
            //    //await context.Response.WriteAsync(_config["MyKey"]); //lee el valor de appsettings.json

            //});

            //app.Run(async (context) =>
            //{
            //    //logger.LogInformation("MW1: Incomming Request");
            //    //logger.LogInformation("MW1: Outgoing Response");
            //    //await context.Response.WriteAsync(Process.GetCurrentProcess().ProcessName);
            //    //await context.Response.WriteAsync("Hola Mundo");
            //    //await context.Response.WriteAsync(_config["MyKey"]); //lee el valor de appsettings.json
            //    await context.Response.WriteAsync("MW3: Request Handled and response produced");
            //    logger.LogInformation("MW3 Request Handeled and responde produced");

            //});
        }
    }
}

//MVC = Model View Controller
//model = clases de datos 
//view = display data

