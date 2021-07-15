using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class DocumentFile : BaseEntity
    {
        public string FilePath { get; set; }
        public Guid AnnouncementId { get; set; }
        public Announcements Announcements { get; set; }
    }
}
