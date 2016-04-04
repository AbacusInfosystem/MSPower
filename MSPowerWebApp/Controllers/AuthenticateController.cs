using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSPowerWebApp.Models;
using MSPowerInfo;
using System.Web.Security;
using MSPowerWebApp.Common;
using MSPowerManager;
using ExceptionManagement.Logger;

namespace MSPowerWebApp.Controllers
{
    public class AuthenticateController : Controller

    {
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            try
            {
                if (User.Identity.IsAuthenticated && Session["User"] != null)
                {
                    return RedirectToAction("Index", "Language");
                }
                else
                {
                    if (TempData["FriendlyMessage"] != null)
                    {
                        loginViewModel.Friendly_Message.Add((FriendlyMessageInfo)TempData["FriendlyMessage"]);
                    }

                    return View("Index", loginViewModel);
                }
            }
            catch (Exception ex)
            {
                loginViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                return View("Index", loginViewModel);
            }
        }

        [HttpPost]

        public ActionResult Authenticate(LoginViewModel loginViewModel)
        {
            try
            {
                AuthenticateManager aMan = new AuthenticateManager();

                //UserInfo user = aMan.AuthenticateUser(loginViewModel.User.User_Name, loginViewModel.User.Password);

                //if (user.UserId != 0 && user.Is_Active == true)

                if (loginViewModel.User.User_Name == "admin" && loginViewModel.User.Password == "admin")
                {

                    FormsAuthentication.SetAuthCookie(loginViewModel.User.User_Name, false);

                    //set values in Users Session object.

                    SetUsersSession(loginViewModel.User.User_Name, loginViewModel.User.Password);

                    if (Session["returnURL"] != null && !string.IsNullOrEmpty(Session["returnURL"].ToString()))
                    {
                        string returnURL = Session["returnURL"].ToString();

                        Session.Remove("returnURL");

                        Response.Redirect(returnURL);
                    }

                    return RedirectToAction("Index", "Language");
                }
                else
                {
                    if (loginViewModel.User.UserId != 0 && loginViewModel.User.Is_Active == false)
                    {
                        TempData["FriendlyMessage"] = MessageStore.Get("SYS06");
                    }
                    else
                    {
                        TempData["FriendlyMessage"] = MessageStore.Get("SYS03");
                    }

                    return RedirectToAction("Index", "Authenticate");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.Clear();

                loginViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                return RedirectToAction("Index", "Home", loginViewModel);
            }
        }

        public ActionResult Logout()
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                LogoutUser();
            }
            catch (Exception ex)
            {
                //Logger.Error("HomeController - Logout: " + ex.ToString());
            }

            return View("Index", loginViewModel);
        }

        private void SetUsersSession(string username, string password)
        {
            LoginViewModel loginViewModel = new LoginViewModel();

            try
            {
                AuthenticateManager aMan = new AuthenticateManager();

                // loginViewModel.User = aMan.SetSession(username, password);

                loginViewModel.User = new UserInfo() { UserId = 1, Name = "Shakti" };

                if (HttpContext.Session["User"] == null)
                {
                    HttpContext.Session.Add("User", loginViewModel.User);
                }
                else
                {
                    HttpContext.Session["User"] = loginViewModel.User;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("HomeController - SetUsersSession: " + ex.ToString());

                HttpContext.Session.Clear();
            }
        }

        private void LogoutUser()
        {
            Session["User"] = null;

            Session["ReturnURL"] = null;

            FormsAuthentication.SignOut();

            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddYears(-1);

            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);

            Response.Expires = -1500;

            Response.CacheControl = "no-cache";

            Response.AddHeader("Cache-Control", "no-cache");

            Response.Cache.SetNoStore();

            Response.AddHeader("Pragma", "no-cache");

            Response.Redirect("/");
        }

    }
}
