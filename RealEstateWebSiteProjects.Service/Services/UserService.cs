using Mapster;
using Microsoft.EntityFrameworkCore;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Contract.CustomModels.Role;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Core.Entities;
using RealEstateWebSiteProjects.Data;
using RealEstateWebSiteProjects.Service.IServices;
using RealEstateWebSiteProjects.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(AppDbContexts context, IUnitOfWork uow) : base(context, uow)
        {

        }

        public async Task<AddUserModel> AddUser(AddUserModel model)
        {
            if (model != null)
            {
                var user = model.Adapt<User>();
                user.Password = "123456";
                user.RoleId = model.RoleId;
                user.RecordUserId = model.CreateUserId;

                await AddAsync(user);
                await _uow.CommitAsync();
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<ChangePasswordModel> ChangePassword(ChangePasswordModel model)
        {
            var user = await _dbContext.User.Where(b => b.Id == model.CreateUserId && !b.IsDeleted).FirstOrDefaultAsync();
            if (user != null)
            {
                if (user.Password != model.OldPassword || model.NewPassword != model.ConfirmPassword)
                {
                    return null;
                }
                else
                {
                    user.Password = model.NewPassword;
                    user.UpdateUserId = model.CreateUserId;

                    await _uow.CommitAsync();
                    return model;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<UserModel> DeleteUser(ByIdModel model)
        {
            var user = await _dbContext.User.Where(b => b.Id == model.Id && !b.IsDeleted).FirstOrDefaultAsync();

            if (user != null)
            {
                user.IsDeleted = true;
                user.UpdateUserId = model.CreateUserId;

                await _uow.CommitAsync();

                return user.Adapt<UserModel>();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<RoleListModel>> ListRole()
        {
            var roleList = await _dbContext.Role.Where(b => !b.IsDeleted).ToListAsync();
            if (roleList != null)
            {
                return roleList.Select(item => item.Adapt<RoleListModel>()).ToList();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<UserModel>> ListUser()
        {
            var userList = await _dbContext.User.Where(b => !b.IsDeleted).ToListAsync();

            if (userList != null)
            {
                var map = userList.Select(item => item.Adapt<UserModel>()).ToList();
                return map;
            }
            else
            {
                return null;
            }
        }

        public async Task<UserModel> UpdateUser(UserModel model)
        {
            var user = await _dbContext.User.Where(b => b.Id == model.Id && !b.IsDeleted).FirstOrDefaultAsync();
            if (user != null)
            {
                user = model.Adapt(user);
                user.UpdateUserId = model.CreateUserId;

                await _uow.CommitAsync();
                return model;
            }
            else
            {
                return null;
            }

        }

        public async Task<UserModel> UpdateUserById(ByIdModel model)
        {
            var user = await _dbContext.User.Where(b => b.Id == model.Id && !b.IsDeleted).FirstOrDefaultAsync();
            if (user != null)
            {
                return user.Adapt<UserModel>();
            }
            else
            {
                return null;
            }
        }

        public async Task<UserProfileModel> UpdateUserProfile(UserProfileModel model)
        {
            var user = await _dbContext.User.Where(b => !b.IsDeleted && b.Id == model.Id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.RegisterName = model.RegisterName;
                user.FullName = model.FullName;
                user.UpdateUserId = model.CreateUserId;

                var save = await _uow.CommitAsync();
                if (save)
                {
                    var userProfile = await _dbContext.UserProfile.Where(b => !b.IsDeleted && b.UserId == model.Id).FirstOrDefaultAsync();
                    if (userProfile != null)
                    {
                        userProfile.TelephoneNumber = model.TelephoneNumber;
                        userProfile.Email = model.Email;
                        userProfile.Address = model.Address;
                        userProfile.Description = model.Description;
                        userProfile.UserId = model.Id;
                        userProfile.UpdateUserId = model.CreateUserId;

                        await _uow.CommitAsync();
                    }
                    else
                    {
                        UserProfile profile = new UserProfile();
                        profile.TelephoneNumber = model.TelephoneNumber;
                        profile.Email = model.Email;
                        profile.Address = model.Address;
                        profile.Description = model.Description;
                        profile.UserId = model.Id;
                        profile.RecordUserId = model.CreateUserId;

                        await _dbContext.UserProfile.AddAsync(profile);
                        await _uow.CommitAsync();
                    }

                    return model;

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

        public async Task<UserProfileModel> UserProfileById(ByIdModel model)
        {
            UserProfileModel profile = new UserProfileModel();
            var user = await _dbContext.User.Where(b => b.Id == model.Id && !b.IsDeleted).Include(b => b.UserProfileList).FirstOrDefaultAsync();
            if (user != null)
            {
                profile.UserModel = user.Adapt<UserModel>();

                var userProfile = await _dbContext.UserProfile.Where(b => !b.IsDeleted && b.UserId == model.Id).FirstOrDefaultAsync();
                if (userProfile != null)
                {
                    var map = userProfile.Adapt<UserProfileModel>();
                    map.UserModel = user.Adapt<UserModel>();

                    return map;
                }
                else
                {
                    return profile;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
