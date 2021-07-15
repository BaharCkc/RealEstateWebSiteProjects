using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.BaseModel
{
    public class ByIdModel
    {
        public Guid Id { get; set; }
        public Guid CreateUserId { get; set; }
    }
}
