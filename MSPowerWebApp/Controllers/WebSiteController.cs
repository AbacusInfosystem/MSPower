using ExceptionManagement.Logger;
using MSPowerInfo;
using MSPowerManager;
using MSPowerWebApp.Common;
using MSPowerWebApp.Filters;
using MSPowerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSPowerWebApp.Controllers
{
    public class WebSiteController : Controller
    {
        //
        // GET: /WebSite/

        [Language]
        public ActionResult Index(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ProductListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult Product(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ServiceListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult Service(string language)
        {
            return View();
        }

        [Language]
        public ActionResult NewsLetterListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult NewsLetter(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ContactUsListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ContactUs(string language)
        {
            return View();
        }

        [Language]
        public ActionResult AboutUs(string language)
        {
            return View();
        }

        [Language]
        public ActionResult Job_OpeningListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult Job_Application(string language)
        {
            Job_ApplicationViewModel jaViewModel = new Job_ApplicationViewModel();

            return View(jaViewModel);
        }

        [Language]
        public ActionResult Insert_Job_Application(Job_ApplicationViewModel jaViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.en);
                }

                else
                {
                    jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.ch);
                }

                jaViewModel.Job_Application.Created_On = DateTime.Now;

                Job_ApplicationManager jaMan = new Job_ApplicationManager();

                //jaViewModel.Job_Application.Job_Application_Id = 1;

                jaViewModel.Job_Application.Job_Application_Id = jaMan.Insert_Job_Application(jaViewModel.Job_Application);

                jaViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }

            catch (Exception ex)
            {

                jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["jaViewModel"] = jaViewModel;

            //return RedirectToAction("Search");

            return View("Job_Application", jaViewModel);

        }

    }
}
