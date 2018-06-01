using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreOdata.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreOdata
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
            services.AddDbContext<MyContext>(config => {
                config.UseSqlServer("Data Source=localhost;Initial Catalog=CoreOdata;Integrated Security=True;Application Name=CoreOdata");
            });
            services.AddMvc();
            services.AddOData();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            var builder = new ODataConventionModelBuilder(app.ApplicationServices);
            builder.EnableLowerCamelCase(options: NameResolverOptions.ProcessReflectedPropertyNames);
            builder.EntitySet<Vehicle>("Vehicles");

            app.UseMvc(routes =>
            {
                // Enable all OData functions
                //routes.Select().Filter();

                routes.MapODataServiceRoute(routeName: "ODataRouter", routePrefix: "api", model: builder.GetEdmModel());

                //routes.EnableDependencyInjection();

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapSpaFallbackRoute(
                //    name: "spa-fallback",
                //    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
