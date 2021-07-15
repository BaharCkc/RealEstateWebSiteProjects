using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementCategory;
using RealEstateWebSiteProjects.Contract.CustomModels.AnnouncementType;
using RealEstateWebSiteProjects.Contract.CustomModels.City;
using RealEstateWebSiteProjects.Contract.CustomModels.County;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateWebSiteProjects.Contract.CustomModels.Announcement
{
    public class AddAnnouncementListModel
    {
        public List<CityListModel> CityList { get; set; } = new List<CityListModel>();
        public List<CountyListModel> CountyList { get; set; } = new List<CountyListModel>();
        public List<AnnouncementTypeListModel> AnnouncementTypeList { get; set; } = new List<AnnouncementTypeListModel>();
        public List<AnnouncementCategoryListModel> AnnouncementCategoryList { get; set; } = new List<AnnouncementCategoryListModel>();
    }
}
