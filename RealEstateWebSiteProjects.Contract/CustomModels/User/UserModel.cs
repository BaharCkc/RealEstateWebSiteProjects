using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.User
{
    public class UserModel : ByIdModel
    {
        //public Guid Id { get; set; }
        public string FullName { get; set; }
        public string RegisterName { get; set; }


    }
}
