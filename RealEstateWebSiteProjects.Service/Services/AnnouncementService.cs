using Mapster;
using Microsoft.EntityFrameworkCore;
using RealEstateWebSiteProjects.Contract.CustomModels.Announcement;
using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementCategory;
using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementType;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Contract.CustomModels.City;
using RealEstateWebSiteProjects.Contract.CustomModels.County;
using RealEstateWebSiteProjects.Contract.CustomModels.DocumentAnnouncement;
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
    public class AnnouncementService : BaseService<Announcements>, IAnnouncementService
    {
        public AnnouncementService(AppDbContexts context, IUnitOfWork uow) : base(context, uow)
        {

        }

        public async Task<AddAnnouncementModel> AddAnnouncement(AddAnnouncementModel model)
        {
            if (model != null)
            {
                Random random = new Random();
                var announcemet = model.Adapt<Announcements>();
                announcemet.Number = random.Next();
                announcemet.UserId = model.CreateUserId;
                announcemet.RecordUserId = model.CreateUserId;

                await AddAsync(announcemet);
                var save = await _uow.CommitAsync();
                if (save)
                {
                    if (model.FilePath != null && model.FilePath.Count > 0)
                    {
                        foreach (var item in model.FilePath)
                        {
                            DocumentFile file = new DocumentFile();
                            file.FilePath = item;
                            file.AnnouncementId = announcemet.Id;
                            file.RecordUserId = model.CreateUserId;
                            file.RecordDate = DateTime.Now;

                            _dbContext.DocumentFile.Add(file);
                        }
                        _dbContext.SaveChanges();
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<AddAnnouncementListModel> AddAnnouncementList()
        {
            AddAnnouncementListModel model = new AddAnnouncementListModel();

            var city = await _dbContext.City.Where(b => !b.IsDeleted).ToListAsync();
            var county = await _dbContext.County.Where(b => !b.IsDeleted).ToListAsync();
            var annoCategory = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
            var annoType = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();

            model.CityList = city.Select(item => item.Adapt<CityListModel>()).ToList();
            model.CountyList = county.Select(item => item.Adapt<CountyListModel>()).ToList();
            model.AnnouncementCategoryList = annoCategory.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
            model.AnnouncementTypeList = annoType.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();

            return model;
        }

        public async Task<DocumentAnnouncementListModel> AnnouncementList()
        {
            DocumentAnnouncementListModel model = new DocumentAnnouncementListModel();
            List<FileAnnouncementListModel> file = new List<FileAnnouncementListModel>();

            var announcementList = await _dbContext.Announcements.Where(b => !b.IsDeleted).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).ToListAsync();
            var typeList = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();
            var categoryList = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
            foreach (var item in announcementList)
            {
                var docFiles = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == item.Id).FirstOrDefaultAsync();

                var map = docFiles.Adapt<FileAnnouncementListModel>();

                file.Add(map);
            }
            if (announcementList != null)
            {
                model.AnnouncementList = announcementList.Select(item => item.Adapt<AnnouncementListModel>()).ToList();
                model.AnnouncementTypeList = typeList.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();
                model.AnnouncementCategoryList = categoryList.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
                model.DocumentFileList = file;
                return model;
            }

            else
            {
                return null;
            }
        }

        public async Task<AnnouncementListModel> DeleteAnnouncement(ByIdModel model)
        {
            var announcemet = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.Id == model.Id).FirstOrDefaultAsync();
            if (announcemet != null)
            {
                announcemet.IsDeleted = true;
                announcemet.UpdateUserId = model.CreateUserId;

                await _uow.CommitAsync();
                return announcemet.Adapt<AnnouncementListModel>();
            }
            else
            {
                return null;
            }
        }

        public async Task<DocumentAnnouncementListModel> GetAnnoucementByCategoryId(ByIdModel model)
        {
            DocumentAnnouncementListModel models = new DocumentAnnouncementListModel();
            List<FileAnnouncementListModel> file = new List<FileAnnouncementListModel>();

            var announcementList = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.AnnouncementCategoryId == model.Id).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).ToListAsync();
            var typeList = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();
            var categoryList = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
            foreach (var item in announcementList)
            {
                var docFiles = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == item.Id).FirstOrDefaultAsync();

                var map = docFiles.Adapt<FileAnnouncementListModel>();

                file.Add(map);
            }
            if (announcementList != null)
            {
                models.AnnouncementList = announcementList.Select(item => item.Adapt<AnnouncementListModel>()).ToList();
                models.AnnouncementTypeList = typeList.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();
                models.AnnouncementCategoryList = categoryList.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
                models.DocumentFileList = file;
                return models;
            }

            else
            {
                return null;
            }
        }
        public async Task<DocumentAnnouncementListModel> GetAnnoucementByTypeId(ByIdModel model)
        {
            DocumentAnnouncementListModel models = new DocumentAnnouncementListModel();
            List<FileAnnouncementListModel> file = new List<FileAnnouncementListModel>();

            var announcementList = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.AnnouncementTypeId == model.Id).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).ToListAsync();
            var typeList = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();
            var categoryList = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
            foreach (var item in announcementList)
            {
                var docFiles = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == item.Id).FirstOrDefaultAsync();

                var map = docFiles.Adapt<FileAnnouncementListModel>();

                file.Add(map);
            }
            if (announcementList != null)
            {
                models.AnnouncementList = announcementList.Select(item => item.Adapt<AnnouncementListModel>()).ToList();
                models.AnnouncementTypeList = typeList.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();
                models.AnnouncementCategoryList = categoryList.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
                models.DocumentFileList = file;
                return models;
            }
            else
            {
                return null;
            }
        }
        public async Task<DocumentAnnouncementListModel> GetAnnoucementByDateId(bool dateValue)
        {
            DocumentAnnouncementListModel models = new DocumentAnnouncementListModel();
            List<FileAnnouncementListModel> file = new List<FileAnnouncementListModel>();
            List<Announcements> announcementList = new List<Announcements>();
            if (dateValue == true)
            {
                announcementList = await _dbContext.Announcements.Where(b => !b.IsDeleted).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).OrderByDescending(b => b.RecordDate).ToListAsync();
            }
            else
            {
                announcementList = await _dbContext.Announcements.Where(b => !b.IsDeleted).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).OrderBy(b => b.RecordDate).ToListAsync();
            }

            var typeList = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();
            var categoryList = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
            foreach (var item in announcementList)
            {
                var docFiles = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == item.Id).FirstOrDefaultAsync();

                var map = docFiles.Adapt<FileAnnouncementListModel>();

                file.Add(map);
            }
            if (announcementList != null)
            {
                models.AnnouncementList = announcementList.Select(item => item.Adapt<AnnouncementListModel>()).ToList();
                models.AnnouncementTypeList = typeList.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();
                models.AnnouncementCategoryList = categoryList.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
                models.DocumentFileList = file;
                return models;
            }
            else
            {
                return null;
            }
        }
        public async Task<GetTypeAnnouncementModel> GetAnnouncementType()
        {
            GetTypeAnnouncementModel model = new GetTypeAnnouncementModel();
            List<FileAnnouncementListModel> file = new List<FileAnnouncementListModel>();

            var announcement = await _dbContext.Announcements.Where(b => !b.IsDeleted).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).Include(b => b.City).ToListAsync();

            if (announcement != null && announcement.Count > 0)
            {
                foreach (var item in announcement)
                {
                    var docFiles = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == item.Id).FirstOrDefaultAsync();

                    var map = docFiles.Adapt<FileAnnouncementListModel>();

                    file.Add(map);
                }

                model.AnnouncementList = announcement.Select(item => item.Adapt<SingleAnnouncementModel>()).ToList();
                model.DocumentFileList = file;
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<DocumentAnnouncementListModel> MyAnnouncementList(ByIdModel model)
        {
            DocumentAnnouncementListModel models = new DocumentAnnouncementListModel();
            List<FileAnnouncementListModel> file = new List<FileAnnouncementListModel>();

            var announcementList = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.UserId == model.Id).Include(b => b.AnnouncementCategory).Include(b => b.AnnouncementType).ToListAsync();
            var typeList = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();
            var categoryList = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
            foreach (var item in announcementList)
            {
                var docFiles = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == item.Id).FirstOrDefaultAsync();

                var map = docFiles.Adapt<FileAnnouncementListModel>();

                file.Add(map);
            }
            if (announcementList != null)
            {
                models.AnnouncementList = announcementList.Select(item => item.Adapt<AnnouncementListModel>()).ToList();
                models.AnnouncementTypeList = typeList.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();
                models.AnnouncementCategoryList = categoryList.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
                models.DocumentFileList = file;
                return models;
            }

            else
            {
                return null;
            }
        }

        public async Task<AddAnnouncementModel> UpdateAnnouncement(AddAnnouncementModel model)
        {
            var announcemet = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.Id == model.Id).FirstOrDefaultAsync();
            if (announcemet != null)
            {
                announcemet = model.Adapt(announcemet);
                announcemet.UserId = model.CreateUserId;
                announcemet.UpdateUserId = model.CreateUserId;

                var save = await _uow.CommitAsync();
                if (save)
                {
                    var files = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == announcemet.Id).ToListAsync();
                    _dbContext.DocumentFile.RemoveRange(files);

                    if (model.FilePath != null && model.FilePath.Count > 0)
                    {
                        foreach (var item in model.FilePath)
                        {
                            DocumentFile file = new DocumentFile();
                            file.FilePath = item;
                            file.AnnouncementId = announcemet.Id;
                            file.RecordUserId = model.CreateUserId;
                            file.RecordDate = DateTime.Now;

                            _dbContext.DocumentFile.Add(file);
                        }
                        _dbContext.SaveChanges();
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task<AnnouncementListModel> UpdateAnnouncementById(ByIdModel model)
        {
            var announcemet = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.Id == model.Id).FirstOrDefaultAsync();

            if (announcemet != null)
            {
                var city = await _dbContext.City.Where(b => !b.IsDeleted).ToListAsync();
                var county = await _dbContext.County.Where(b => !b.IsDeleted).ToListAsync();
                var annoCategory = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted).ToListAsync();
                var annoType = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted).ToListAsync();
                var docs = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == model.Id).ToListAsync();

                var map = announcemet.Adapt<AnnouncementListModel>();

                map.CityList = city.Select(item => item.Adapt<CityListModel>()).ToList();
                map.CountyList = county.Select(item => item.Adapt<CountyListModel>()).ToList();
                map.AnnouncementCategoryList = annoCategory.Select(item => item.Adapt<AnnouncementCategoryListModel>()).ToList();
                map.AnnouncementTypeList = annoType.Select(item => item.Adapt<AnnouncementTypeListModel>()).ToList();
                map.FileDocumentList = docs.Select(item => item.Adapt<FileAnnouncementListModel>()).ToList();
                return map;

            }
            else
            {
                return null;
            }
        }
        public async Task<SingleAnnouncementModel> DetailsAnnouncementById(ByIdModel model)
        {
            var announcemet = await _dbContext.Announcements.Where(b => !b.IsDeleted && b.Id == model.Id).FirstOrDefaultAsync();

            if (announcemet != null)
            {
                var city = await _dbContext.City.Where(b => !b.IsDeleted && b.Id == announcemet.CityId).FirstOrDefaultAsync();
                var county = await _dbContext.County.Where(b => !b.IsDeleted && b.Id == announcemet.CountyId).FirstOrDefaultAsync();
                var annoCategory = await _dbContext.AnnouncementCategory.Where(b => !b.IsDeleted && b.Id == announcemet.AnnouncementCategoryId).FirstOrDefaultAsync();
                var annoType = await _dbContext.AnnouncementType.Where(b => !b.IsDeleted && b.Id == announcemet.AnnouncementTypeId).FirstOrDefaultAsync();
                var docs = await _dbContext.DocumentFile.Where(b => !b.IsDeleted && b.AnnouncementId == announcemet.Id).ToListAsync();
                var user = await _dbContext.User.Where(b => !b.IsDeleted && b.Id == announcemet.UserId).FirstOrDefaultAsync();
                var userprofile = await _dbContext.UserProfile.Where(b => !b.IsDeleted && b.UserId == announcemet.UserId).FirstOrDefaultAsync();

                var map = announcemet.Adapt<SingleAnnouncementModel>();

                map.City = city.Adapt<CityListModel>();
                map.County = county.Adapt<CountyListModel>();
                map.AnnouncementCategory = annoCategory.Adapt<AnnouncementCategoryListModel>();
                map.AnnouncementType = annoType.Adapt<AnnouncementTypeListModel>();
                map.FileDocumentList = docs.Select(item => item.Adapt<FileAnnouncementListModel>()).ToList();
                if (userprofile != null)
                {
                    map.UserProfile = userprofile.Adapt<UserProfileModel>();
                }
                map.UserProfile.UserModel = user.Adapt<UserModel>();
                return map;

            }
            else
            {
                return null;
            }
        }

        public async Task<List<CountyListModel>> GetCountyByCityId(ByIdModel model)
        {
            var countyList = await _dbContext.County.Where(b => !b.IsDeleted && b.CityId == model.Id).ToListAsync();

            if (countyList != null && countyList.Count > 0)
            {
                return countyList.Select(item => item.Adapt<CountyListModel>()).ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
