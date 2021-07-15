using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class County : BaseEnum
    {
        public County(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }
        public Guid? CityId { get; set; }
        public City City { get; set; }
        //public virtual List<Announcements> AnnouncementsList { get; set; } = new List<Announcements>();
    }
}
