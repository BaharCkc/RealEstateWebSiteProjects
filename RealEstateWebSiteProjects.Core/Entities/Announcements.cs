using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Entities
{
    public class Announcements: BaseEntity
    {
        public int Number { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid AnnouncementCategoryId { get; set; }
        public AnnouncementCategory AnnouncementCategory { get; set; }
        public Guid AnnouncementTypeId { get; set; }
        public AnnouncementType AnnouncementType { get; set; }
        public string NetSquareMeter { get; set; }
        public string GrossSquareMeter { get; set; }
        public string NumberOfRooms { get; set; }
        public string NumberOfBathrooms { get; set; }
        public string FloorLocation { get; set; }
        public bool? IsArticle { get; set; }
        public int? HousingAge { get; set; }
        public string Address { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public Guid CountyId { get; set; }
        //public County County { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public virtual List<DocumentFile> DocumentFileList { get; set; } = new List<DocumentFile>();
    }
}
