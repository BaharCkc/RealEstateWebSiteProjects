using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementCategory;
using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementType;
using RealEstateWebSiteProjects.Contract.CustomModels.DocumentAnnouncement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.Announcement
{
    public class DocumentAnnouncementListModel
    {
        public List<AnnouncementTypeListModel> AnnouncementTypeList { get; set; } = new List<AnnouncementTypeListModel>();
        public List<FileAnnouncementListModel> DocumentFileList { get; set; } = new List<FileAnnouncementListModel>();
        public List<AnnouncementListModel> AnnouncementList { get; set; } = new List<AnnouncementListModel>();
        public List<AnnouncementCategoryListModel> AnnouncementCategoryList { get; set; } = new List<AnnouncementCategoryListModel>();
    }
}
