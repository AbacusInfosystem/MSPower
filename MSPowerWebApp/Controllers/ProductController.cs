using MSPowerWebApp.Filters;
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
    public class ProductController : Controller
    
    {
        //
        // GET: /Product/

        public ProductManager _pMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(ProductViewModel pViewModel)
        {
            _pMan = new ProductManager();

            //if (Session["Language"].ToString() == Language.en.ToString())
            //{
            //    pViewModel.Product_Categories = _pMan.Get_Product_Categories(Convert.ToInt32(Language.en));
            //}
            //else
            //{
            //    pViewModel.Product_Categories = _pMan.Get_Product_Categories(Convert.ToInt32(Language.ch));
            //}

            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(pViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(ProductViewModel pViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["pViewModel"] != null)
            {
                pViewModel = (ProductViewModel)TempData["pViewModel"];
            }

            return View("Search", pViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(ProductViewModel pViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    pViewModel.Product.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    pViewModel.Product.Language_Id = Convert.ToInt32(Language.ch);
                }

                pViewModel.Product.Created_By = ((UserInfo)Session["User"]).UserId;

                pViewModel.Product.Updated_By = ((UserInfo)Session["User"]).UserId;

                pViewModel.Product.Created_On = DateTime.Now;

                pViewModel.Product.Updated_On = DateTime.Now;

                ProductManager pMan = new ProductManager();

                //pViewModel.Product.Product_Id = 1;

                pViewModel.Product.Product_Id = pMan.Insert_Product(pViewModel.Product);

                pViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["pViewModel"] = pViewModel;

            //return RedirectToAction("Search");

            return View("Index", pViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(ProductViewModel pViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    pViewModel.Product.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    pViewModel.Product.Language_Id = Convert.ToInt32(Language.ch);
                }


                pViewModel.Product.Updated_On = DateTime.Now;

                pViewModel.Product.Updated_By = ((UserInfo)Session["User"]).UserId;

                ProductManager pMan = new ProductManager();

                pMan.Update_Product(pViewModel.Product);

                pViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
           
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["pViewModel"] = pViewModel;

            //return RedirectToAction("Search");

            return View("Index", pViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(ProductViewModel pViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    pViewModel.Product.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    pViewModel.Product.Language_Id = Convert.ToInt32(Language.ch);
                }


                pViewModel.Product.Updated_On = DateTime.Now;

                pViewModel.Product.Updated_By = ((UserInfo)Session["User"]).UserId;

                ProductManager pMan = new ProductManager();

                // this should be delete method.

                //pMan.Update_Product(pViewModel.Product);

                pViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Product_By_Id(ProductViewModel pViewModel)
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


                ProductManager pMan = new ProductManager();

                pViewModel.Product = pMan.Get_Product_By_Id(pViewModel.Filter.Product_Id, language_Id);
            }

            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", pViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Products(ProductViewModel pViewModel)
        {
            ProductManager pMan = new ProductManager();

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

                pager = pViewModel.Pager;
                
                pViewModel.Products = pMan.Get_Products(ref pager, language_Id);
                
                pViewModel.Pager = pager;

                pViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pViewModel.Pager.TotalRecords, pViewModel.Pager.CurrentPage + 1, pViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);

        }
    }
}
