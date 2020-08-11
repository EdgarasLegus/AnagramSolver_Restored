using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramSolver.EF.DatabaseFirst;
using AnagramSolver.Interfaces;
using AnagramSolver.Interfaces.DBFirst;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnagramSolver.WebApp
{
    public class Startup
    {
        private readonly string connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;" +
            "Integrated Security = true;Uid=auth_windows";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            UI.Configuration.BuilderConfigurations();

            services
                .AddScoped<IAnagramSolver, BusinessLogic.AnagramSolver>()
                .AddScoped<IWordRepository, Repos.FRepository>()
                .AddScoped<IDatabaseLogic, BusinessLogic.DatabaseLogic>()
                .AddScoped<IUI, UI.UI>()
                .AddScoped<IEFLogic, BusinessLogic.EFLogic>()
                .AddScoped<IEFRepository, Repos.EFRepository>()
                .AddHttpContextAccessor();

            services.AddDbContext<AnagramSolverDBFirstContext>(options => options.UseSqlServer(connectionString));
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

            //Important
            app.UseRouting();

            app.UseAuthorization();

            //Without parametrs will have MapDefaultControllerRoute
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "paging",
                //    pattern: "{controller=Anagram}/{action=Index}/{pageIndex?}");
            });
        }
    }
}
