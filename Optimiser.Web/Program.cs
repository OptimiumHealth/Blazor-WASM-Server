using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NLog.Web;

using System;

namespace Optimiser.Web;

public class Program
{
    public static void Main(string[] args)
    {
        // NLog: setup the logger first to catch all errors
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        try
        {
            logger.Debug("______________________________________________________________________");
            logger.Debug("Building and Starting Host in Main()");

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Host.UseNLog();

            logger.Debug("");

            logger.Debug("Adding AddRazorPages...");
            builder.Services.AddRazorPages();

#if BlazorWebAssembly
            logger.Debug("Beginning to configure services in WASM mode");
#else
            logger.Debug("Beginning to configure services in Server mode");

            // Adds the Server-Side Blazor services, and those registered by the app project's startup.
            logger.Debug("Adding AddServerSideBlazor...");
            builder.Services.AddServerSideBlazor();

#endif
            logger.Debug("Completed configure services");

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                logger.Debug("UseDeveloperExceptionPage...");
                app.UseDeveloperExceptionPage();
#if BlazorWebAssembly
                app.UseWebAssemblyDebugging();
#endif
            }
            else
            {
                logger.Debug("UseExceptionHandler...");
                app.UseExceptionHandler("/Error");

                logger.Debug("UseHsts...");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            logger.Debug("UseHttpsRedirection...");
            app.UseHttpsRedirection();

#if BlazorWebAssembly

            logger.Debug("UseBlazorFrameworkFiles...");
            app.UseBlazorFrameworkFiles();

#endif

            logger.Debug("UseStaticFiles...");
            app.UseStaticFiles();

            logger.Debug("UseRouting...");
            app.UseRouting();

            logger.Debug("UseEndpoints...");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
#if BlazorWebAssembly
                endpoints.MapFallbackToPage("/index_webassembly");
#else
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/index_server");
#endif
            });

            logger.Debug("Completed startup, now executing app.Run()");
            app.Run();
        }
        catch (Exception ex)
        {
            //NLog: catch setup errors
            logger.Error(ex, "Stopped program because of exception");
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            logger.Debug("Shutting down NLOG");
            NLog.LogManager.Shutdown();
        }
    }

}
