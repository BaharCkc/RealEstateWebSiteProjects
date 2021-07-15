using RealEstateWebSiteProjects.Contract.CustomModels.Announcement;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Contract.CustomModels.County;
using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Service.IServices
{
    public interface IAnnouncementService : IBaseService<Announcements>
    {
        Task<DocumentAnnouncementListModel> AnnouncementList();
        Task<DocumentAnnouncementListModel> MyAnnouncementList(ByIdModel model);
        Task<GetTypeAnnouncementModel> GetAnnouncementType();
        Task<AnnouncementListModel> DeleteAnnouncement(ByIdModel model);
        Task<List<CountyListModel>> GetCountyByCityId(ByIdModel model);
        Task<AnnouncementListModel> UpdateAnnouncementById(ByIdModel model);
        Task<SingleAnnouncementModel> DetailsAnnouncementById(ByIdModel model);
        Task<DocumentAnnouncementListModel> GetAnnoucementByCategoryId(ByIdModel model);
        Task<DocumentAnnouncementListModel> GetAnnoucementByTypeId(ByIdModel model);
        Task<DocumentAnnouncementListModel> GetAnnoucementByDateId(bool dateValue);
        Task<AddAnnouncementListModel> AddAnnouncementList();
        Task<AddAnnouncementModel> AddAnnouncement(AddAnnouncementModel model);
        Task<AddAnnouncementModel> UpdateAnnouncement(AddAnnouncementModel model);
    }
}
