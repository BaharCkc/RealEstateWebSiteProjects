using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class Role : BaseEnum
    {
        public Role(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; }
        public virtual List<User> UserList { get; set; } = new List<User>();
    }
}
