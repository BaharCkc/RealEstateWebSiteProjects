using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.User
{
    public class AddUserModel : ByIdModel
    {
        public string FullName { get; set; }
        public string RegisterName { get; set; }
        public Guid RoleId { get; set; }
    }
}
