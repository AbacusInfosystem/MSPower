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
        public ActionResult NewsLetterListing(string language, NewsLetterViewModel nlViewModel)
        {
            NewsLetterManager nlMan = new NewsLetterManager();

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

                pager = nlViewModel.Pager;

                nlViewModel.NewsLetters = nlMan.Get_NewsLetters(ref pager, language_Id);

                nlViewModel.Pager = pager;

                nlViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", nlViewModel.Pager.TotalRecords, nlViewModel.Pager.CurrentPage + 1, nlViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View(nlViewModel);

        }

        public ActionResult Get_NewsLetter_By_Id(int NewsLetter_Id)
        {

            NewsLetterViewModel nlViewModel = new NewsLetterViewModel();

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

                NewsLetterManager nlMan = new NewsLetterManager();

                nlViewModel.NewsLetter = nlMan.Get_NewsLetter_By_Id(NewsLetter_Id, language_Id);
            }

            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("NewsLetter", nlViewModel);
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

        public ActionResult AboutUs(string language, AboutUsViewModel auViewModel)
        {

            AboutUsManager auMan = new AboutUsManager();

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

                auViewModel.AboutUs = auMan.Get_AboutUs(language_Id);

            }
            catch (Exception ex)
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
              
            }

            return View(auViewModel);

        }
            
        [Language]

        public ActionResult Job_OpeningListing(string language, Job_OpeningViewModel joViewModel)
        {

            Job_OpeningManager joMan = new Job_OpeningManager();

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

                pager = joViewModel.Pager;

                joViewModel.Job_Openings = joMan.Get_Job_Openings(ref pager, language_Id);

                joViewModel.Pager = pager;

                joViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", joViewModel.Pager.TotalRecords, joViewModel.Pager.CurrentPage + 1, joViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View(joViewModel);

        }

        public ActionResult Get_Job_Opening_By_Id(int Job_Opening_Id)
        {
            Job_OpeningViewModel joViewModel = new Job_OpeningViewModel();

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

                Job_OpeningManager joMan = new Job_OpeningManager();

                //joViewModel.Job_Opening = joMan.Get_Job_Opening_By_Id(joViewModel.Job_Opening.Job_Opening_Id);

                joViewModel.Job_Opening = joMan.Get_Job_Opening_By_Id(Job_Opening_Id, language_Id);
            }

            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Job_Opening", joViewModel);
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

                //jaViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
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


        [Language]

        public ActionResult Enquiry(string language)
        {
            EnquiryViewModel eViewModel = new EnquiryViewModel();

            if (Session["Language"].ToString() == Language.en.ToString())
            {
                eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.en);
            }

            else
            {
                eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.ch);
            }

            return View(eViewModel);
        }

        [Language]

        public ActionResult Insert_Enquiry(string language, EnquiryViewModel eViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.en);
                }

                else
                {
                    eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.ch);
                }

                eViewModel.Enquiry.Created_On = DateTime.Now;

                EnquiryManager eMan = new EnquiryManager();

                eViewModel.Enquiry.Enquiry_Id = eMan.Insert_Enquiry(eViewModel.Enquiry);

                //eViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }

            catch (Exception ex)
            {

                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            return View("Enquiry", eViewModel);

        }

    }
}
