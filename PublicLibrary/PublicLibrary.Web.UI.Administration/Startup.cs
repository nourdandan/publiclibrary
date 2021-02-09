using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublicLibrary.DAL.Infrastructure;
using PublicLibrary.BAL.Services;
using PublicLibrary.DAL.Repositories;
using Microsoft.Extensions.Logging;
using PublicLibrary.Web.UI.Administration.Helpers;

namespace PublicLibrary.Web.UI.Administration
{
    public class Startup
    {
        public Startup(IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();

            services.AddLogging();

            services.AddDbContext<DAL.PublicLibraryContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PublicLibraryContext")));

            services.AddTransient<IDbFactory, DbFactory>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IFormRepository, FormRepository>();
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<IFormsService, FormsService>();
            services.AddTransient<IErrorHandler, ErrorHandler>();

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
                    pattern: "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
