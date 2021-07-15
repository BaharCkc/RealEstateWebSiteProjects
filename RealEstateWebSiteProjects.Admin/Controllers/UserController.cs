using FormHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateWebSiteProjects.Contract.CustomModels.BaseModel;
using RealEstateWebSiteProjects.Contract.CustomModels.User;
using RealEstateWebSiteProjects.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _userService.ListUser());
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            ViewBag.RoleList = await _userService.ListRole();
            return View();
        }
        [HttpPost]
        [FormValidator]
        public async Task<IActionResult> AddUser(AddUserModel model)
        {
            var userId = Guid.Parse(HttpContext.Session.GetString("id"));

            if (model != null)
            {
                model.CreateUserId = userId;
                var data = await _userService.AddUser(model);
                if (data != null)
                {
                    return Json(new { failed = false, message = "Kullanıcı başarılı bir şekilde kaydedildi." });
                }
                else
                {
                    return Json(new { failed = true, message = "Kullanıcı bilgileri kaydedilirken bir hata oluştu, lütfen tekrar deneyiniz." });
                }
            }
            else
            {
                return Json(new { failed = true, message = "Kullanıcı bilgileri alınamadı, lütfen zorunlu alanları doldurarak tekrar deneyiniz." });
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateUserById(ByIdModel model)
        {
            if (model != null)
            {
                var data = await _userService.UpdateUserById(model);
                if (data != null)
                {
                    return View(data);
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı Bulunamadı";
                    return RedirectToAction("Index", "User");
                }

            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcıya ait bilgi bulunamadı";
                return RedirectToAction("Index", "User");
            }
        }
        [HttpPost]
        [FormValidator]
        public async Task<IActionResult> UpdateUser(UserModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            if (model != null)
            {
                model.CreateUserId = user;
                var data = await _userService.UpdateUser(model);
                if (data != null)
                {
                    return Json(new { failed = false, message = "Kullanıcı başarıyla güncellendi" });
                }
                else
                {
                    return Json(new { failed = true, message = "Kullanıcı bilgileri bulunamadı, lütfen tekrar deneyiniz." });

                }
            }
            else
            {
                return Json(new { failed = true, message = "Kullanıcı bilgileri güncellenirken bir hata oluştu, lütfen tekrar deneyiniz." });

            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(ByIdModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            if (model != null)
            {
                model.CreateUserId = user;
                var data = await _userService.DeleteUser(model);
                if (data != null)
                {
                    return Json(new { failed = false, message = "Kullanıcı başarıyla silinmiştir" });
                }
                else
                {
                    return Json(new { failed = true, message = "Kullanıcı bilgileri bulunamadı, lütfen tekrar deneyiniz." });

                }
            }
            else
            {
                return Json(new { failed = true, message = "Kullanıcı bilgileri silinirken bir hata oluştu, lütfen tekrar deneyiniz." });

            }
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            if (model != null)
            {
                model.CreateUserId = user;
                var data = await _userService.ChangePassword(model);
                if (data != null)
                {
                    return Json(new { failed = false, message = "Şifre başarıyla güncellendi" });
                }
                else
                {
                    return Json(new { failed = true, message = "Şifre bilgileri bulunamadı, lütfen tekrar deneyiniz." });
                }
            }
            else
            {
                return Json(new { failed = true, message = "Şifre güncellenirken bir hata oluştu, lütfen tekrar deneyiniz." });
            }
        }
        
        public async Task<IActionResult> UserProfileById()
        {
            ByIdModel model = new ByIdModel();
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            if (user != null)
            {
                model.Id = user;
                var data = await _userService.UserProfileById(model);
                if (data != null)
                {
                    return View(data);
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı Bulunamadı";
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                TempData["ErrorMessage"] = "Kullanıcıya ait bilgi bulunamadı";
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [FormValidator]
        public async Task<IActionResult> UpdateUserProfile(UserProfileModel model)
        {
            var user = Guid.Parse(HttpContext.Session.GetString("id"));
            if (model != null)
            {
                model.CreateUserId = user;
                var data = await _userService.UpdateUserProfile(model);
                if (data != null)
                {
                    return FormResult.CreateSuccessResult("Kullanıcı bilgileri güncellendi.", Url.Action("UserProfileById", "User"));
                }
                else
                {
                    return FormResult.CreateErrorResult("Kullanıcı bilgileri bulunamadı, lütfen tekrar deneyiniz.!", Url.Action("UserProfileById", "User"));

                }
            }
            else
            {
                return FormResult.CreateErrorResult("Kullanıcı bilgileri güncellenirken bir hata oluştu, lütfen tekrar deneyiniz.!", Url.Action("UserProfileById", "User"));
            }
        }
    }
}
