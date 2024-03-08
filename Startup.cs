
using GrapeCity.ActiveReports.Aspnetcore.Viewer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
namespace ActiveReportsCoreMVCApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _ = services
                .AddLogging(config =>
                {
                    // Disable the default logging configuration
                    _ = config.ClearProviders();
                    // Enable logging for debug mode only
                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                    {
                        _ = config.AddConsole();
                    }
                })
                .AddReportViewer()
                .AddMvc(option => option.EnableEndpointRouting = false);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }
            app.UseReportViewer(settings =>
            {
                string reportsFolder = Path.Combine(env.ContentRootPath, "Reports");
                settings.UseFileStore(new DirectoryInfo(reportsFolder));
            });
            _ = app.UseStaticFiles();
            _ = app.UseMvc();
        }
    }
}

