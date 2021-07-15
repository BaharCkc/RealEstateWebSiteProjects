using FluentValidation.AspNetCore;
using FormHelper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RealEstateWebSiteProjects.Admin.IoC;
using RealEstateWebSiteProjects.Data;
using RealEstateWebSiteProjects.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Admin
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
            ServiceInjector.Add(services);
            ValidationInjector.Add(services);

            //services.AddControllersWithViews().AddRazorRuntimeCompilation(); //sayfa yenilemek icin            
            services.AddControllersWithViews().AddFluentValidation().AddRazorRuntimeCompilation();

            services.AddFormHelper(new FormHelperConfiguration
            {
                CheckTheFormFieldsMessage = "Form alanlarýný kontrol ediniz."
                //RedirectDelay->Yönlendirme iþlemlerinde beklenecek varsayýlan süre.
                //ToastrDefaultPosition->Bildirim / Uyarý mesajlarýnýn ekranda görüneceði pozisyon.
            });


            services.AddDbContext<AppDbContexts>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o => {
                    o.MigrationsAssembly("RealEstateWebSiteProjects.Data");
                });
            });

            //services.AddControllersWithViews();
            services.AddSession();
            services.AddRazorPages();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/Home/NotFoundPage");

            app.UseFormHelper();

            // uygulamanýn varsayýlan dilini Türkçe olarak çalýþmaya zorlamak icin
            var cultureInfo = new CultureInfo("tr-TR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            AppDbSeed.Initialize(app.ApplicationServices, true);
        }
    }
}
