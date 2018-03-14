using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurboERP_DAL.Models;
using TurboERP_DAL.Controllers;
using System.Net;


namespace TurboERP_DAL.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()

        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usermast model)
        {
            if (ModelState.IsValid)
            {
                string Login_Name = string.Empty;
                var LoginList = new AccountApiController().GetLogin(model.Login_Name.Trim()).FirstOrDefault();
                if (LoginList != null)
                {
                    if (LoginList.Password.Trim() == model.Password.Trim())
                    {
                        while (LoginList.Name != null)
                        {
                            Session["EMPNAME"] = LoginList.Name;
                            Session["Code"] = LoginList.Code.TrimEnd();
                            return View("Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "User Name Or Password is incorrect!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User Name Or Password s incorrect!");
                }
            }
            else
            {
                ModelState.AddModelError("", "User Name Or Password s incorrect!");
            }
            return View();
        }
        public ActionResult LogOff()
        {
            Session["EMPNAME"] = null;
            Session["Code"] = null;
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}

