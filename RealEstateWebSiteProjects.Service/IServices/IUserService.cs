using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Contract.CustomModels.Role;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Service.IServices
{
    public interface IUserService : IBaseService<User>
    {
        Task<List<UserModel>> ListUser();
        Task<List<RoleListModel>> ListRole();
        Task<AddUserModel> AddUser(AddUserModel model);
        Task<UserModel> DeleteUser(ByIdModel model);
        Task<UserModel> UpdateUserById(ByIdModel model);
        Task<UserProfileModel> UserProfileById(ByIdModel model);
        Task<UserModel> UpdateUser(UserModel model);
        Task<UserProfileModel> UpdateUserProfile(UserProfileModel model);
        Task<ChangePasswordModel> ChangePassword(ChangePasswordModel model);
    }
}
