using Mapster;
using Microsoft.EntityFrameworkCore;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Core.Entities;
using RealEstateWebSiteProjects.Data;
using RealEstateWebSiteProjects.Service.IServices;
using RealEstateWebSiteProjects.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateWebSiteProjects.Service.Services
{
    public class LoginService : BaseService<User>, ILoginService
    {
        public LoginService(AppDbContexts context, IUnitOfWork uow) : base(context, uow)
        {

        }
        public AddSessionUserModel CheckUser(LoginUserModel model)
        {
            if (model.RegisterName != null && model.Password != null)
            {
                var user = _dbContext.User.Where(b => b.RegisterName == model.RegisterName && b.Password == model.Password && !b.IsDeleted).Include(b => b.Role).FirstOrDefault();

                if (user != null)
                {
                    var map = user.Adapt<AddSessionUserModel>();
                    map.RoleName = user.Role.Description;
                    return map;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
    }
}
