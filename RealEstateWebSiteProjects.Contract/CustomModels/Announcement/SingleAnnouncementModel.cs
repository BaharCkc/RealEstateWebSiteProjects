using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementCategory;
using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementType;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Contract.CustomModels.City;
using RealEstateWebSiteProjects.Contract.CustomModels.County;
using RealEstateWebSiteProjects.Contract.CustomModels.DocumentAnnouncement;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.Announcement
{
    public class SingleAnnouncementModel : ByIdModel
    {
        public int Number { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid AnnouncementCategoryId { get; set; }
        public Guid AnnouncementTypeId { get; set; }
        public string NetSquareMeter { get; set; }
        public string GrossSquareMeter { get; set; }
        public string NumberOfRooms { get; set; }
        public string NumberOfBathrooms { get; set; }
        public string FloorLocation { get; set; }
        public bool? IsArticle { get; set; }
        public int? HousingAge { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public Guid UserId { get; set; }
        public UserProfileModel UserProfile { get; set; } = new UserProfileModel();
        public CityListModel City { get; set; } = new CityListModel();
        public CountyListModel County { get; set; } = new CountyListModel();
        public AnnouncementTypeListModel AnnouncementType { get; set; } = new AnnouncementTypeListModel();
        public AnnouncementCategoryListModel AnnouncementCategory { get; set; } = new AnnouncementCategoryListModel();
        public List<FileAnnouncementListModel> FileDocumentList { get; set; } = new List<FileAnnouncementListModel>();
    }
}
