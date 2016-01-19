using ExceptionManagement.Logger;
using MSPowerInfo;
using MSPowerManager;
using MSPowerWebApp.Common;
using MSPowerWebApp.Filters;
using MSPowerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
            ProductDetailViewModel pViewModel = new ProductDetailViewModel();

            ProductDetailManager _pMan = new ProductDetailManager();

            int language_Id = 0;

            

            if(Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            try
            {
                pViewModel.Product_Categories = _pMan.Get_Product_Categories_By_Lanugae_Id(language_Id);

                pViewModel.Language = language;
            }
            catch(Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("WebSite Controller - ProductListing" + ex.ToString());
            }

            return View(pViewModel);
        }

        [Language]
        public ActionResult Product(string language, int product_Column_Ref_Id, int product_Category_Column_Mapping_Id)
        {
            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            ProductDetailManager pdMan = new ProductDetailManager();

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            int language_Id = 0;



            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            try
            {
                pdViewModel.Product_Category_Column_Mapping = pdMan.Get_Product_Category_Column_By_Id(product_Category_Column_Mapping_Id);

                pdViewModel.Product_Category = pdMan.Get_Product_Category_By_Id(pdViewModel.Product_Category_Column_Mapping.Product_Category_Id, language_Id);

                pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(product_Column_Ref_Id);

                pdViewModel.Product_Details = pdMan.Get_Product_Details(ref pager, product_Category_Column_Mapping_Id, product_Column_Ref_Id);

                foreach (var item in pdViewModel.Product_Details)
                {
                    string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), item.Product_Detail_Id + ".pdf");

                    if (System.IO.File.Exists(path))
                    {
                        item.Is_PDF_Exists = true;
                    }
                    else
                    {
                        item.Is_PDF_Exists = false;
                    }
                }
            }
            catch(Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("WebSite Controller - Product" + ex.ToString());
            }

            return View(pdViewModel);
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

        [Language]
        public PartialViewResult Get_Product_Search(string language)
        {
            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            ProductDetailManager _pMan = new ProductDetailManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            try
            {
                pdViewModel.Product_Categories = _pMan.Get_Product_Categories_By_Lanugae_Id(language_Id);

                pdViewModel.Language = language;
            }
            catch(Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Web Site Controller - Get_Product_Details" + ex.ToString());
            }

            return PartialView("_Product_Search", pdViewModel);
        }

         [Language]
        public ActionResult Events(string language)
        {
            EventViewModel eViewModel = new EventViewModel();

             EventManager _eMan = new EventManager();

              int language_Id = 0;

            if(Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

             PaginationInfo pager = new PaginationInfo();

             pager.IsPagingRequired = false;

            try
            {
                eViewModel.Events = _eMan.Get_Events(ref pager, language_Id);
            }
             catch(Exception ex)
            {
                Logger.Error("Web Site Controller - Events" + ex.ToString());
            }

            return View("Events", eViewModel);
        }

         public PartialViewResult Get_Events_Images(int event_Id)
         {
             EventViewModel eViewModel = new EventViewModel();

             eViewModel.Event.Event_Id = event_Id;

             try
             {
                 string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath1"]).ToString(), event_Id.ToString());

                 if (System.IO.Directory.Exists(path))
                 {
                     string[] fileEntries = Directory.GetFiles(path);

                     foreach (string fileName in fileEntries)
                     {
                         eViewModel.File_Name.Add(Path.GetFileName(fileName));
                     }
                 }
             }
             catch (Exception ex)
             {
                 Logger.Error("Web Site Controller - Get_Events_Images" + ex.ToString());
             }

             return PartialView("_Events_Images", eViewModel);
         }

         public ActionResult SetLanguage(string language)
         {
             try
             {
                 Session["Language"] = language;
             }
             catch(Exception ex)
             {
                 Logger.Error("Web Site Controller - Get_Events_Images" + ex.ToString());
             }
             return RedirectToAction("Index");
         }

    }
}
