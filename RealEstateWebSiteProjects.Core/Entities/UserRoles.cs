using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class UserRoles :BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
