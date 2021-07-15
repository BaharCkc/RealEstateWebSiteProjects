using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.User
{
    public class AddSessionUserModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string RegisterName { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
