using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class City :BaseEnum
    {
        public City(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }
        public virtual List<Announcements> AnnouncementsList { get; set; } = new List<Announcements>();
        public virtual List<County> CountyList { get; set; } = new List<County>();
    }
}
