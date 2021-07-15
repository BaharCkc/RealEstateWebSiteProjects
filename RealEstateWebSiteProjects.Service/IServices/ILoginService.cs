using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Service.IServices
{
    public interface ILoginService : IBaseService<User>
    {
        AddSessionUserModel CheckUser(LoginUserModel model);
    }
}
