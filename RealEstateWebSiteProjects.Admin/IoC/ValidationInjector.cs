using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RealEstateWebSiteProjects.Contract.CustomModels.Announcement;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Admin.IoC
{
    public class ValidationInjector
    {
        public static void Add(IServiceCollection services)
        {
            services.AddTransient<IValidator<AddUserModel>, AddUserValidators >();
            services.AddTransient<IValidator<LoginUserModel>, LoginValidators>();
            services.AddTransient<IValidator<UserModel>, UpdateUserValidators>();
            services.AddTransient<IValidator<AddAnnouncementModel>, AddAnnouncementValidators>();
            services.AddTransient<IValidator<UserProfileModel>, UpdateUserProfileValidator>();
        }
    }
}
