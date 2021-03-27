using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<OnlineBookstoreDbContext>(options =>
                options.UseSqlite(Configuration["ConnectionStrings:OnlineBookstoreConnection"]));

            services.AddScoped<iOnlineBookstoreRepository,EFOnlineBookstoreRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //Change the url endpoints to be what we want
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    "page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    "category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "Books/{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            //Run this function and pull in app from SeedData
            SeedData.EnsurePopulated(app);
        }
    }
}
