//
//  Optimiser.Web.Startup
//
//  2019-04-18  Mark Stega
//              Created
//

#if BlazorWebAssembly
#else
using System.Net.Http;
#endif

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Optimiser.Web
{
    public class Startup
    {
        NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            logger.Debug("");

            logger.Debug("Adding AddRazorPages...");
            services.AddRazorPages();

#if BlazorWebAssembly
            logger.Debug("Beginning Startup.ConfigureServices() in WASM mode");
#else
            logger.Debug("Beginning Startup.ConfigureServices() in Server mode");

            // Adds the Server-Side Blazor services, and those registered by the app project's startup.
            logger.Debug("Adding AddServerSideBlazor...");
            services.AddServerSideBlazor();

#endif

            logger.Debug("Completed Startup.ConfigureServices()");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            logger.Debug("");
            logger.Debug("Beginning Startup.Configure()");

            if (env.IsDevelopment())
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
            logger.Debug("UseClientSideBlazorFiles...");
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

            logger.Debug("Completed Startup.Configure()");
        }
    }

}
