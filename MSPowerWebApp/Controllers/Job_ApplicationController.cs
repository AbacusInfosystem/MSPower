using MSPowerWebApp.Filters;
using MSPowerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MSPowerInfo;
using MSPowerWebApp.Common;
using MSPowerManager;
using ExceptionManagement.Logger;
using CaptchaMvc.HtmlHelpers;
using System.Configuration;
using System.IO;

namespace MSPowerWebApp.Controllers
{
    public class Job_ApplicationController : Controller
    {
        //
        // GET: /Job_Application/

        //[Language]

        //public ActionResult Index(string language)
        //{
        //    Job_ApplicationViewModel jaViewModel = new Job_ApplicationViewModel();

        //    return View(jaViewModel);
        //}


        //[HttpPost]

        //public ActionResult Index(string empty)
        //{
        //    // Code for validating the CAPTCHA 
 
        //    if (this.IsCaptchaValid("Captcha is not valid"))
        //    {

        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ErrMessage = "Error: captcha is not valid.";

        //    Job_ApplicationViewModel jaViewModel = new Job_ApplicationViewModel();

        //    return View(jaViewModel);
        //}  


        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(Job_ApplicationViewModel jaViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["jaViewModel"] != null)
            {
                jaViewModel = (Job_ApplicationViewModel)TempData["jaViewModel"];
            }

            return View("Search", jaViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        //public ActionResult Insert(Job_ApplicationViewModel jaViewModel)
        //{
        //    try
        //    {
        //        if (Session["Language"].ToString() == Language.en.ToString())
        //        {
        //            jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.en);
        //        }

        //        else
        //        {
        //            jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.ch);
        //        }

        //        jaViewModel.Job_Application.Created_On = DateTime.Now;

        //        Job_ApplicationManager jaMan = new Job_ApplicationManager();

        //        //jaViewModel.Job_Application.Job_Application_Id = 1;

        //        jaViewModel.Job_Application.Job_Application_Id = jaMan.Insert_Job_Application(jaViewModel.Job_Application);

        //        jaViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
        //    }

        //    catch (Exception ex)
        //    {

        //        jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Test Controller - Insert" + ex.ToString());
        //    }

        //    //TempData["jaViewModel"] = jaViewModel;

        //    //return RedirectToAction("Search");

        //    return View("Index", jaViewModel);

        //}

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        //public ActionResult Update(Job_ApplicationViewModel jaViewModel)
        //{
        //    try
        //    {
        //        jaViewModel.Job_Application.Updated_On = DateTime.Now;

        //        jaViewModel.Job_Application.Updated_By = ((UserInfo)Session["User"]).UserId;

        //        Job_ApplicationManager jaMan = new Job_ApplicationManager();

        //        jaMan.Update_Job_Application(jaViewModel.Job_Application);

        //        jaViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
        //    }
        //    catch (Exception ex)
        //    {
        //        jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Test Controller - Update" + ex.ToString());
        //    }

        //    //TempData["jaViewModel"] = jaViewModel;

        //    //return RedirectToAction("Search");

        //    return View("Index", jaViewModel);

        //}

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(Job_ApplicationViewModel jaViewModel)
        {
            try
            {

                if(Session["Language"].ToString() == Language.en.ToString())
                {
                    jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.ch);
                }

                Job_ApplicationManager jaMan = new Job_ApplicationManager();

                // this should be delete method.

                //jaMan.Update_Job_Application(jaViewModel.Job_Application);

                jaViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }

            catch (Exception ex)
            {
                jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["jaViewModel"] = jaViewModel;

            return View("Index", jaViewModel);

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT..

        public ActionResult Get_Job_Application_By_Id(Job_ApplicationViewModel jaViewModel)
        {
            try
            {
                int language_Id = 0;

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    language_Id = Convert.ToInt32(Language.en);
                }

                else
                {
                    language_Id = Convert.ToInt32(Language.ch);
                }

                Job_ApplicationManager jaMan = new Job_ApplicationManager();

                jaViewModel.Job_Application = jaMan.Get_Job_Application_By_Id(jaViewModel.Filter.Job_Application_Id, language_Id);

                string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), jaViewModel.Job_Application.Job_Application_Id + ".docx");

                if (jaViewModel.Job_Application.Job_Application_Id != 0)
                {
                    if (System.IO.File.Exists(path))
                    {
                        jaViewModel.Job_Application.Is_DOCX_Exists = true;
                    }
                    else
                    {
                        jaViewModel.Job_Application.Is_DOCX_Exists = false;
                    }
                }
            }

            catch (Exception ex)
            {
                jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Job_ApplicationDetail", jaViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Job_Applications(Job_ApplicationViewModel jaViewModel)
        {
            Job_ApplicationManager jaMan = new Job_ApplicationManager();

            PaginationInfo pager = new PaginationInfo();

            try
            {
                int language_Id = 0;

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    language_Id = Convert.ToInt32(Language.ch);
                }

                pager = jaViewModel.Pager;

                jaViewModel.Job_Applications = jaMan.Get_Job_Applications(ref pager, language_Id);

                jaViewModel.Pager = pager;

                jaViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", jaViewModel.Pager.TotalRecords, jaViewModel.Pager.CurrentPage + 1, jaViewModel.Pager.PageSize, 10, true);

                for (int i = 0; i < jaViewModel.Job_Applications.Count; i++)
                {
                    // check for docx

                    string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), jaViewModel.Job_Applications[i].Job_Application_Id + ".docx");

                    if (CheckPathExists(path))
                    {
                        jaViewModel.Job_Applications[i].Is_DOCX_Exists = true;
                    }

                    // check for doc

                    if (jaViewModel.Job_Applications[i].Is_DOCX_Exists != true)
                    {
                        path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), jaViewModel.Job_Applications[i].Job_Application_Id + ".doc");

                        jaViewModel.Job_Applications[i].Is_DOCX_Exists = CheckPathExists(path);
                    }
                }

                
                    }
                    catch (Exception ex)
                    {
                        jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                        Logger.Error("Test Controller - Get_Tests" + ex.ToString());
                    }

                    finally
                    {
                        pager = null;
                    }

                    return Json(jaViewModel, JsonRequestBehavior.AllowGet);

                }

        // Check if the Docx file exist

        private bool CheckPathExists(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public FileResult Download_Job_Application_Details_DOCX(int job_application_Id)
        {
            string path = "";

            try
            {
                path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), job_application_Id + ".docx");
            }
            catch (Exception ex)
            {
                Logger.Error("Job Application Details Controller - Download_Job_Application_Details_DOCX" + ex.ToString());
            }

            return File(path, "application/docx", "Job Application Details.docx");
        }


    }
}
