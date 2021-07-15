using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstateWebSiteProjects.Core.Constants;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RealEstateWebSiteProjects.Data.Contexts
{
    public static class AppDbSeed
    {
        private static void GetAndAddEnums<TEntity, TEnum>(this DbContext dbContext, bool create,
 IDictionary<TEnum, Guid> ids) where TEntity : BaseEnum
        {
            foreach (TEnum e in Enum.GetValues(typeof(TEnum)))
            {

                var name = e.ToString();
                var query = dbContext.Set<TEntity>().SingleOrDefault(q => q.Name == name);
                if (query != null)
                {
                    ids.Add(e, query.Id);
                }
                else if (create)
                {
                    var memberInfo = typeof(TEnum).GetMember(name)[0];
                    var hasDisplayAttribute = Attribute.IsDefined(memberInfo, typeof(DisplayAttribute));
                    var displayAttribute =
                        hasDisplayAttribute ? memberInfo.GetCustomAttribute<DisplayAttribute>() : null;

                    if (displayAttribute?.Description != null)
                    {
                        var newEntity =
                            (TEntity)Activator.CreateInstance(typeof(TEntity), name, displayAttribute.Description);
                        newEntity.RecordDate = DateTime.Now;
                        var entity = dbContext.Set<TEntity>().Add(newEntity).Entity;
                        dbContext.SaveChanges();
                        ids.Add(e, entity.Id);
                    }
                    else
                    {
                        var newEntity = (TEntity)Activator.CreateInstance(typeof(TEntity), name);
                        var entity = dbContext.Set<TEntity>().Add(newEntity).Entity;
                        dbContext.SaveChanges();
                        ids.Add(e, entity.Id);
                    }
                }
            }
        }
        public static async void Initialize(IServiceProvider serviceProvider, bool create = false)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<AppDbContexts>();

            dbContext.Database.Migrate();

            dbContext.GetAndAddEnums<Role, Constants.Role>(create, Constants.RoleIds);
            dbContext.GetAndAddEnums<City, Constants.City>(create, Constants.CityIds);
            dbContext.GetAndAddEnums<County, Constants.County>(create, Constants.CountyIds);
            dbContext.GetAndAddEnums<AnnouncementType, Constants.AnnouncementType>(create, Constants.AnnouncementTypeIds);
            dbContext.GetAndAddEnums<AnnouncementCategory, Constants.AnnouncementCategory>(create, Constants.AnnouncementCategoryIds);

            var users = await dbContext.User.Where(b => b.RegisterName == "admin" && !b.IsDeleted).FirstOrDefaultAsync();
            if (users is null)
            {
                var role = await dbContext.Role.Where(b => b.Description == "Admin" && !b.IsDeleted).FirstOrDefaultAsync();

                User user = new User();
                user.FullName = "Bahar Çakıcı";
                user.RegisterName = "admin";
                user.RoleId = role.Id;
                user.Password = "123";
                user.RecordDate = DateTime.Now;
                user.RecordUserId = Guid.NewGuid();

                await dbContext.User.AddAsync(user);
                await dbContext.SaveChangesAsync();

            }

            //var getTotalPartner = await dbContext.Users.Where(t => t.UserName == "172172" && !t.IsDeleted).FirstOrDefaultAsync();

            //if (getTotalPartner != null)
            //{
            //    var getProfile = await dbContext.Profile.Where(t => !t.IsDeleted && t.UserId == getTotalPartner.Id).FirstOrDefaultAsync();
            //    if (getProfile is null)
            //    {
            //        Profile profile = new Profile();
            //        profile.FirstPersonName = "Hayrettin";
            //        profile.FirstPersonSurname = "Uçar";
            //        profile.FirstPersonEmail = "hayrettin@gmail.com";
            //        profile.RecordUserId = Guid.NewGuid();
            //        profile.UserId = getTotalPartner.Id;
            //        profile.RecordDate = DateTime.Now;
            //        profile.InvoiceAddress = "Fatura adresi";
            //        profile.DeliveryAddress = "Kargo adresi";
            //        profile.ContactAddress = "İletişim adresi";
            //        await dbContext.Profile.AddAsync(profile);
            //        await dbContext.SaveChangesAsync();
            //    }

            //}
        }
    }
}
