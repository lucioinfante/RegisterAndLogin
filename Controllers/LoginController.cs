using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorized]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            MyLogger.GetInstance().Info("Entering the PrivateSectionMustBeLoggedIn method");
            MyLogger.GetInstance().Info("Leaving the PrivateSectionMustBeLoggedIn method");
            return Content("I am a protected method if the proper attribute is applied to me.");
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            MyLogger.GetInstance().Info("Entering the Process Login method");
            MyLogger.GetInstance().Info("Parameter: " + user.ToString());

            SecurityService securityService = new SecurityService();

            if(securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login success");
                HttpContext.Session.SetString("username", user.UserName);
                MyLogger.GetInstance().Info("Leaving ProcessLogin");
                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Login failed");
                MyLogger.GetInstance().Info("Leaving ProcessLogin");
                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }
    }
}
