using FormHelper;
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
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [FormValidator]
        public IActionResult Login(LoginUserModel model)
        {
            var user = _loginService.CheckUser(model);
            if (user != null)
            {
                HttpContext.Session.SetString("username", user.FullName);
                HttpContext.Session.SetString("id", user.Id.ToString());
                HttpContext.Session.SetString("rolename", user.RoleName);

                if (user.RoleName == "Admin")
                {
                    return FormResult.CreateSuccessResult("Giriş başarılı, anasayfaya yönlendiriliyorsunuz.", Url.Action("AnnouncementList", "Announcement"));

                }
                else if (user.RoleName == "Superuser")
                {
                    return FormResult.CreateSuccessResult("Giriş başarılı, anasayfaya yönlendiriliyorsunuz.", Url.Action("MyAnnouncementList", "Announcement"));

                }
                else if (user.RoleName == "User")
                {
                    return FormResult.CreateSuccessResult("Giriş başarılı, anasayfaya yönlendiriliyorsunuz.", Url.Action("AnnouncementList", "Announcement"));
                }
                else
                {
                    return FormResult.CreateErrorResult("Kullanıcı Adı veya Şifre Yanlış!", Url.Action("Index", "Login"));
                }
            }
            else
            {
                return FormResult.CreateErrorResult("Kullanıcı Adı veya Şifre Yanlış!");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
