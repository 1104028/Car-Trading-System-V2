using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTradingSystem.ViewModel;
using CarTradingSystem.Models;
using CarTradingSystem.DataLayer;
using System.Web.Security;

namespace CarTradingSystem.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        // [Authorize]
        // [HttpPost]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginView login, string ReturnUrl = "")
        {

            if (ModelState.IsValid)
            {
                if(CarTradingDBAccess.IsAdminExist(login.UserName,login.Password))
                {
                    int timeout = login.RememberMe ? 525600 : 60; // 525600 min = 1 year
                    var ticket = new FormsAuthenticationTicket(login.UserName, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("UserName", "User name and password not matched!!!");
                    return View();
                }
                

            }
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(AdminRegistration request)
        {
            if(ModelState.IsValid)
            {
                AdminAccount admin = new AdminAccount();
                admin.ContactNumber = request.ContactNumber;
                admin.Email = request.Email;
                admin.Name = request.Name;
                admin.Password = request.Password;
                admin.UserName = request.UserName;
                if(CarTradingDBAccess.AddAdmin(admin))
                {
                    ViewBag.message = "Admin has been added successfully";
                    AdminRegistration tem = new AdminRegistration();
                    return View(tem);
                }
                else
                {
                    ViewBag.message = "Operation Failed!!";
                }
            }
            return View();
        }
        [RBAC]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult EmailUpdate()
        {
            EmailInformation emailInf = new EmailInformation();
            var Email = CarTradingDBAccess.GetEmail();
            if (Email != null)
                emailInf = Email;
            return View(emailInf);
        }
        [HttpPost]
        public ActionResult EmailUpdate(EmailInformation Email)
        {
            if (ModelState.IsValid)
            {
                if (CarTradingDBAccess.EmailUpdate(Email))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();

        }

    }
}