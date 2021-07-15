using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.DocumentAnnouncement
{
    public class FileAnnouncementListModel : ByIdModel
    {
        public string FilePath { get; set; }
        public Guid AnnouncementId { get; set; }
    }
}
