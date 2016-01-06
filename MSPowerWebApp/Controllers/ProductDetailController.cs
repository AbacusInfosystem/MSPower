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


        public ActionResult Index(ProductDetailViewModel pdViewModel)
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            ProductDetailManager pdMan = new ProductDetailManager();

            pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(pdViewModel.Filter.Product_Column_Ref_Id);

            return View("Index", pdViewModel);

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

        public JsonResult Get_Product_Volts( int product_category_Id)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

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

        public JsonResult Get_Product_Details(int product_category_column_mapping_Id, int  product_column_ref_Id)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

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

                pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(product_column_ref_Id);

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

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        //public ActionResult Insert(ProductDetailViewModel pdViewModel)
        //{
        //    try
        //    {

        //        if (Session["Language"].ToString() == Language.en.ToString())
        //        {
        //            pdViewModel.Product_Details_Header. = Convert.ToInt32(Language.en);
        //        }
        //        else
        //        {
        //            pdViewModel.Product.Language_Id = Convert.ToInt32(Language.ch);
        //        }

        //        pdViewModel.Product.Created_By = ((UserInfo)Session["User"]).UserId;

        //        pdViewModel.Product.Updated_By = ((UserInfo)Session["User"]).UserId;

        //        pdViewModel.Product.Created_On = DateTime.Now;

        //        pdViewModel.Product.Updated_On = DateTime.Now;

        //        ProductManager pMan = new ProductManager();

        //        //pdViewModel.Product.Product_Id = 1;

        //        pdViewModel.Product.Product_Id = pMan.Insert_Product(pdViewModel.Product);

        //        pdViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
        //    }
        //    catch (Exception ex)
        //    {
        //        pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Test Controller - Insert" + ex.ToString());
        //    }

        //    //TempData["pdViewModel"] = pdViewModel;

        //    //return RedirectToAction("Search");

        //    return View("Index", pdViewModel);

        //}

    }
}
