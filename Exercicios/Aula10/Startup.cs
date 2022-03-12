using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula10
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("TestCacheProfile",
                    new CacheProfile
                    {
                        Duration = 20,
                        Location = ResponseCacheLocation.Any,
                        VaryByHeader = "User-Agent"
                    });
            });

            services.AddResponseCaching(options =>
            {
                // some default values can be changed
                options.MaximumBodySize = 20; // default value is 64MB
                options.SizeLimit = 200; // default value is 100MB
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(
                new StaticFileOptions
                {
                    OnPrepareResponse = options =>
                    {
                        options.Context.Response.Headers[HeaderNames.CacheControl] = $"public,max-age={20}";
                        options.Context.Response.Headers[HeaderNames.LastModified] = options.File.LastModified.ToString();
                    }
                });

            app.UseResponseCaching();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
