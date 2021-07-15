using Microsoft.Extensions.DependencyInjection;
using RealEstateWebSiteProjects.Service.IServices;
using RealEstateWebSiteProjects.Service.IUnitOfWorks;
using RealEstateWebSiteProjects.Service.Services;
using RealEstateWebSiteProjects.Service.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Admin.IoC
{
    public class ServiceInjector
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<ILoginService, LoginService>();
        }
    }
}
