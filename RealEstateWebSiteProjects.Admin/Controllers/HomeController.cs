using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public HomeController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _announcementService.GetAnnouncementType();
            if (data != null)
            {
                foreach (var item in data.DocumentFileList)
                {
                    item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
                }
            }
            return View(data);
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }

    }
}
