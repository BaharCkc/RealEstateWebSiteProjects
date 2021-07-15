using FormHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebSiteProjects.Contract.CustomModels.Announcement;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Service.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Admin.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public IWebHostEnvironment _env { get; }

        public AnnouncementController(IAnnouncementService announcementService, IWebHostEnvironment env)
        {
            _announcementService = announcementService;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AnnouncementList()
        {
            var data = await _announcementService.AnnouncementList();
            foreach (var item in data.DocumentFileList)
            {
                item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
            }
            return View(data);
        }
        public async Task<IActionResult> MyAnnouncementList()
        {
            ByIdModel model = new ByIdModel();
            model.Id = Guid.Parse(HttpContext.Session.GetString("id"));
            var data = await _announcementService.MyAnnouncementList(model);
            foreach (var item in data.DocumentFileList)
            {
                item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
            }
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> AddAnnouncement()
        {
            return View(await _announcementService.AddAnnouncementList());
        }
        [HttpPost]
        [FormValidator]
        public async Task<IActionResult> AddAnnouncement(AddAnnouncementModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            model.CreateUserId = user;

            if (model.UploadFile != null)
            {
                List<string> list = new List<string>();

                foreach (var item in model.UploadFile)
                {
                    var g = Guid.NewGuid();
                    var fileName = g.ToString() + item.FileName;
                    var folderName = "wwwroot\\UploadData";
                    var filePath = Path.Combine(_env.ContentRootPath, folderName, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    list.Add(fileName);
                }
                model.FilePath = list;
            }
            else
            {
                return Json(new { failed = true, message = "İlan resimleri eklemeyi tekrar deneyiniz." });
            }
            var addAnnouncemet = await _announcementService.AddAnnouncement(model);
            if (addAnnouncemet != null)
            {

                return Json(new { failed = false, message = "İlan başarıyla kaydedilmiştir." });
            }

            else
            {
                return Json(new { failed = true, message = "İlan kaydedilirken bir hata oluştu, lütfen tekrar deneyiniz." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetAnnoucementByCategoryId(ByIdModel model)
        {
            if (model != null)
            {
                var data = await _announcementService.GetAnnoucementByCategoryId(model);

                if (data != null)
                {
                    foreach (var item in data.DocumentFileList)
                    {
                        item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
                    }

                    return PartialView("~/Views/Announcement/_PartialGetAnnoucementList.cshtml", data);


                }
                else
                {
                    return Json(new { failed = true, message = "İlan bilgileri ile bir hata oluştu, lütfen tekrar deneyiniz." });
                }

            }
            else
            {
                return Json(new { failed = true, message = "İlan bilgileri bulunamadı." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAnnouncement(ByIdModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            model.CreateUserId = user;
            if (model != null)
            {
                var data = await _announcementService.DeleteAnnouncement(model);
                if (data != null)
                {
                    return Json(new { failed = false, message = "İlan başarıyla silindi." });
                }
                else
                {
                    return Json(new { failed = true, message = "İlan silinirken bir hata oluştu, lütfen tekrar deneyiniz." });
                }
            }
            else
            {
                return Json(new { failed = true, message = "İlan bilgileri bulunamadı." });
            }
        }
        public async Task<IActionResult> UpdateAnnouncementById(ByIdModel model)
        {
            if (model != null)
            {
                var data = await _announcementService.UpdateAnnouncementById(model);
                if (data != null)
                {
                    foreach (var item in data.FileDocumentList)
                    {
                        item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
                    }
                    return View(data);
                }
                else
                {
                    ViewBag.ErrorMessage = "İlana ait bilgilerde hata oluştu.";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "İlana ait bilgiler bulunamadı.";
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAnnouncement(AddAnnouncementModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            model.CreateUserId = user;

            if (model.UploadFile != null)
            {
                List<string> list = new List<string>();

                foreach (var item in model.UploadFile)
                {
                    var g = Guid.NewGuid();
                    var fileName = g.ToString() + item.FileName;
                    var folderName = "wwwroot\\UploadData";
                    var filePath = Path.Combine(_env.ContentRootPath, folderName, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }
                    list.Add(fileName);
                }
                model.FilePath = list;
            }
            else
            {
                return Json(new { failed = true, message = "İlan resimleri eklemeyi tekrar deneyiniz." });
            }
            var updateAnnouncemet = await _announcementService.UpdateAnnouncement(model);
            if (updateAnnouncemet != null)
            {

                return Json(new { failed = false, message = "İlan başarıyla güncellenmiştir." });
            }

            else
            {
                return Json(new { failed = true, message = "İlan güncellenirken bir hata oluştu, lütfen tekrar deneyiniz." });
            }

        }
        public async Task<IActionResult> DetailsAnnouncementById(ByIdModel model)
        {
            if (model != null)
            {
                var data = await _announcementService.DetailsAnnouncementById(model);
                if (data != null)
                {
                    foreach (var item in data.FileDocumentList)
                    {
                        item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
                    }
                    return View(data);
                }
                else
                {
                    ViewBag.ErrorMessage = "İlana ait bilgilerde hata oluştu.";
                    return View();
                }

            }
            else
            {
                ViewBag.NullMessage = "İlana ait bilgiler bulunamadı.";
                return View();
            }
        }
        public async Task<PartialViewResult> SelectCounty(ByIdModel model)
        {
            var data = await _announcementService.GetCountyByCityId(model);
            if (data != null)
            {
                return PartialView("~/Views/Announcement/_PartialCountyList.cshtml", data);
            }
            else
            {
                ViewBag.Message = "İlçe Bulunmamaktadır.";
                return PartialView("~/Views/Announcement/_PartialCountyList.cshtml", data);
            }

        }
        public ActionResult DownloadFile(string filePath)
        {
            var file = filePath.Substring(35);
            var folderName = "wwwroot\\UploadData";
            var fileNewPath = Path.Combine(_env.ContentRootPath, folderName, file);

            byte[] fileBytes = GetFile(fileNewPath);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.Substring(36));

        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
        [HttpPost]
        public async Task<IActionResult> GetAnnoucementByTypeId(ByIdModel model)
        {
            if (model != null)
            {
                var data = await _announcementService.GetAnnoucementByTypeId(model);

                if (data != null)
                {
                    foreach (var item in data.DocumentFileList)
                    {
                        item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
                    }

                    return PartialView("~/Views/Announcement/_PartialGetAnnoucementList.cshtml", data);


                }
                else
                {
                    return Json(new { failed = true, message = "İlan bilgileri ile bir hata oluştu, lütfen tekrar deneyiniz." });
                }

            }
            else
            {
                return Json(new { failed = true, message = "İlan bilgileri bulunamadı." });
            }
        }
        [HttpPost]
        public async Task<IActionResult> GetAnnoucementByDate(bool dateValue)
        {
            var data = await _announcementService.GetAnnoucementByDateId(dateValue);

            if (data != null)
            {
                foreach (var item in data.DocumentFileList)
                {
                    item.FilePath = Request.Scheme + "://" + Request.Host + "/UploadData/" + item.FilePath;
                }

                return PartialView("~/Views/Announcement/_PartialGetAnnoucementList.cshtml", data);


            }
            else
            {
                return Json(new { failed = true, message = "İlan bilgileri ile bir hata oluştu, lütfen tekrar deneyiniz." });
            }

        }
    }
}
