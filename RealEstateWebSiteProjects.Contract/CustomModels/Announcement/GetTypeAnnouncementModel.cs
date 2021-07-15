using RealEstateWebSiteProjects.Contract.CustomModels.DocumentAnnouncement;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.Announcement
{
    public class GetTypeAnnouncementModel
    {
        public List<FileAnnouncementListModel> DocumentFileList { get; set; } = new List<FileAnnouncementListModel>();
        public List<SingleAnnouncementModel> AnnouncementList { get; set; } = new List<SingleAnnouncementModel>();
    }
}
