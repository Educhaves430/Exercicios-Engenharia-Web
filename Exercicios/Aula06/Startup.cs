using Aula6.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Aula6
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
            services.AddControllersWithViews();

            services.AddDbContext<Aula6Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Aula6Context")));

            // register my custom class to constraint "letter" value
            services.Configure<RouteOptions>(routeOptions =>
            {
                routeOptions.ConstraintMap.Add("myRule", typeof(MyRulesConstraint));
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "filtered",
                //    pattern: "Filter/{letter?}",
                //    defaults: new { Controller = "Students", Action = "Index2" },
                //    constraints: new { letter = @"[A-Z¬¡…Û”]" }); // regular expression to validate "letter" field

                //endpoints.MapControllerRoute(
                //    name: "filtered",
                //    pattern: "Filter/{letter:alpha:length(1)?}", // Inline Constraint to restrict the letter to one alphabetic character
                //    defaults: new { Controller = "Students", Action = "Index2" }); // regular expression to validate "letter" field

                //endpoints.MapControllerRoute(
                //    name: "filtered",
                //    pattern: "Filter/{letter?}",
                //    defaults: new { Controller = "Students", Action = "Index2" },
                //    constraints: new { letter = new MyRulesConstraint() }); // Extern custom class to implement field constraints

                endpoints.MapControllerRoute(
                    name: "filtered",
                    pattern: "Filter/{letter:myRule?}", // Same class as inline constraint
                    defaults: new { Controller = "Students", Action = "Index2" });

                endpoints.MapControllerRoute(
                    name: "orderby",
                    pattern: "Order/{property?}/{order?}", // Same class as inline constraint
                    defaults: new { Controller = "Students", Action = "Index3" },
                    constraints: new { property = @"byNumber|byName", order = @"Ascending|Descending" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
