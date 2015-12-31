using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MSPowerInfo;
using MSPowerWebApp.Common;
using MSPowerWebApp.Models;
using MSPowerManager;
using ExceptionManagement.Logger;

namespace MSPowerWebApp.Controllers
{
    public class ProductDetailController : Controller
    {
        //
        // GET: /ProductDetail/


        public ActionResult Index()
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View();
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(ProductDetailViewModel pdViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["pdViewModel"] != null)
            {
                pdViewModel = (ProductDetailViewModel)TempData["pdViewModel"];
            }

            return View("Search", pdViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCT CATEGORIES FROM DB.

        public JsonResult Get_Product_Categories(ProductDetailViewModel pdViewModel)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            //PaginationInfo pager = pdViewModel.Pager;

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

                //pager = pdViewModel.Pager;

                pdViewModel.Product_Categories = pdMan.Get_Product_Categories(language_Id);

                //pdViewModel.Pager = pager;

                //pdViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pdViewModel.Pager.TotalRecords, pdViewModel.Pager.CurrentPage + 1, pdViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            

            return Json(pdViewModel, JsonRequestBehavior.AllowGet);

        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCT CATEGORIES FROM DB.

        public JsonResult Get_Product_Volts(ProductDetailViewModel pdViewModel, int product_category_Id)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            //PaginationInfo pager = pdViewModel.Pager;

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

                //pager = pdViewModel.Pager;

                pdViewModel.Volts = pdMan.Get_Product_Volts(product_category_Id);

                //pdViewModel.Pager = pager;

                //pdViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pdViewModel.Pager.TotalRecords, pdViewModel.Pager.CurrentPage + 1, pdViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }

            return Json(pdViewModel, JsonRequestBehavior.AllowGet);

        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCT CATEGORIES FROM DB.

        public JsonResult Get_Product_Details(ProductDetailViewModel pdViewModel, int product_category_column_mapping_Id)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            PaginationInfo pager = pdViewModel.Pager;

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

                pager = pdViewModel.Pager;

                pdViewModel.Product_Details = pdMan.Get_Product_Details(product_category_column_mapping_Id);

                pdViewModel.Pager = pager;

                pdViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pdViewModel.Pager.TotalRecords, pdViewModel.Pager.CurrentPage + 1, pdViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }


            return Json(pdViewModel, JsonRequestBehavior.AllowGet);

        }


    }
}
