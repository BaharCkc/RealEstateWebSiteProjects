using Microsoft.AspNetCore.Http;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.Announcement
{
    public class AddAnnouncementModel : ByIdModel
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid AnnouncementCategoryId { get; set; }
        public Guid AnnouncementTypeId { get; set; }
        public string NetSquareMeter { get; set; }
        public string GrossSquareMeter { get; set; }
        public string NumberOfRooms { get; set; }
        public string NumberOfBathrooms { get; set; }
        public string FloorLocation { get; set; }
        public bool? IsArticle { get; set; }
        public int? HousingAge { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
        public Guid CountyId { get; set; }
        public List<IFormFile> UploadFile { get; set; }
        public List<string> FilePath { get; set; }

    }
}
