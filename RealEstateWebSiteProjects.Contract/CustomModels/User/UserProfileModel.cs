using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.User
{
    public class UserProfileModel : ByIdModel
    {
        public string FullName { get; set; }
        public string RegisterName { get; set; }
        public string TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public UserModel UserModel { get; set; }
    }
}
