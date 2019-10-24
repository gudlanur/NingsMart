using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NingsMart.Models;
using Microsoft.EntityFrameworkCore;

namespace NingsMart
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
            //string connectionStrings = @"Server = LAPTOP-RH26PECK; Database=ProductDB; Trusted_Connection = True; MultipleActiveResultSets=True;";
            //services.AddDbContext<EmpContext>(options => options.UseSqlServer(connectionStrings));
            ////string connectionString = Configuration.GetConnectionString("DevConnection");
            ////services.AddDbContext<ProductContext>(optios => optios.UseSqlServer(connectionString));


            string connectionStrings = @"Server =LAPTOP-RH26PECK; Database = Practice; Trusted_Connection = true; ConnectRetryCount = 0";
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(connectionStrings));
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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
