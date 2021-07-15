using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class AnnouncementCategory : BaseEnum
    {
        public AnnouncementCategory(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }
        public virtual List<Announcements> AnnouncementsList { get; set; } = new List<Announcements>();
    }
}
