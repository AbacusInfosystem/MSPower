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

            try
            {
                pdViewModel.Product_Category_Column_Mapping = pdMan.Get_Product_Category_Column_By_Id(product_Category_Column_Mapping_Id);

                pdViewModel.Product_Category = pdMan.Get_Product_Category_By_Id(pdViewModel.Product_Category_Column_Mapping.Product_Category_Id);

                pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(product_Column_Ref_Id);

                pdViewModel.Product_Details = pdMan.Get_Product_Details(ref pager, product_Category_Column_Mapping_Id, product_Column_Ref_Id);
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

    }
}
