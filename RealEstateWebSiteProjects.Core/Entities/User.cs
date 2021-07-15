using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string RegisterName { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public virtual List<Announcements> AnnouncementsList { get; set; } = new List<Announcements>();
        public virtual List<UserProfile> UserProfileList { get; set; } = new List<UserProfile>();
    }
}
