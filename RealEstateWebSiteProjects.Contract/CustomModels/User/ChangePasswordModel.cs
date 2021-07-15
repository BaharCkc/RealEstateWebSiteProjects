using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.User
{
    public class ChangePasswordModel : ByIdModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
