using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecipeWebsite.Models;

namespace RecipeWebsite
{
    public class Startup
    {
        //public property
        public IConfiguration Configuration { get; }

        //constructor
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeWebsiteRecipes:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:RecipeWebsiteRecipes:ConnectionIdentityString"]));
            services.AddTransient<IRecipeRepository, EFRecipeRepository>();
            //services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.EnsurePopulated(app);
            SeedDataIdentity.EnsurePopulated(app);
        }
    }
}
