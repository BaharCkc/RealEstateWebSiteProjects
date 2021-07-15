using RealEstateWebSiteProjects.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RealEstateWebSiteProjects.Core.Constants
{
    public partial class Constants
    {
        //Role
        public static Dictionary<Role, Guid> RoleIds { get; set; } = new Dictionary<Role, Guid>();
        public enum Role
        {
            [Display(Description = "Admin")] Admin,
            [Display(Description = "Superuser")] Superuser,
            [Display(Description = "User")] User,
        }
        //County
        public static Dictionary<County, Guid> CountyIds { get; set; } = new Dictionary<County, Guid>();
        public enum County
        {
            [Display(Description = "Küçükçekmece")] County1,
            [Display(Description = "Şirinevler")] County2,
            [Display(Description = "Mamak")] County3,
        }
        //City
        public static Dictionary<City, Guid> CityIds { get; set; } = new Dictionary<City, Guid>();
        public enum City
        {
            [Display(Description = "İstanbul")] City1,
            [Display(Description = "Ankara")] City2,
            [Display(Description = "İzmir")] City3,
        }
        //AnnouncementCategory
        public static Dictionary<AnnouncementCategory, Guid> AnnouncementCategoryIds { get; set; } = new Dictionary<AnnouncementCategory, Guid>();
        public enum AnnouncementCategory
        {
            [Display(Description = "Daire")] Apartment,
            [Display(Description = "Arsa")] Plot,
            [Display(Description = "Konut")] Housing,
        }
        //AnnouncementType
        public static Dictionary<AnnouncementType, Guid> AnnouncementTypeIds { get; set; } = new Dictionary<AnnouncementType, Guid>();
        public enum AnnouncementType
        {
            [Display(Description = "Satılık")] ForSale,
            [Display(Description = "Kiralık")] ForRent,
        }

    }
}
