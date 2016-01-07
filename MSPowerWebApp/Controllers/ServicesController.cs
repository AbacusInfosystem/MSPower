using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MSPowerWebApp.Filters;

using MSPowerInfo;
using MSPowerWebApp.Common;
using MSPowerWebApp.Models;
using MSPowerManager;
using ExceptionManagement.Logger;

namespace MSPowerWebApp.Controllers
{
    public class ServicesController : Controller
    {
        //
        // GET: /Services/
        

        public ServicesManager _sMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(ServicesViewModel sViewModel)
        {
            _sMan = new ServicesManager();

            if (Session["Language"].ToString() == Language.en.ToString())
            {
                sViewModel.Service_Categories = _sMan.Get_Services_Categories(Convert.ToInt32(Language.en));  
            } 
            else
            {
                sViewModel.Service_Categories = _sMan.Get_Services_Categories(Convert.ToInt32(Language.ch));
            }

            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(sViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(ServicesViewModel sViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["sViewModel"] != null)
            {
                sViewModel = (ServicesViewModel)TempData["sViewModel"];
            }

            return View("Search", sViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(ServicesViewModel sViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    sViewModel.Service.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    sViewModel.Service.Language_Id = Convert.ToInt32(Language.ch);
                }

                sViewModel.Service.Created_By = ((UserInfo)Session["User"]).UserId;

                sViewModel.Service.Updated_By = ((UserInfo)Session["User"]).UserId;

                sViewModel.Service.Created_On = DateTime.Now;

                sViewModel.Service.Updated_On = DateTime.Now;

                ServicesManager sMan = new ServicesManager();

                //pViewModel.Product.Product_Id = 1;

                sViewModel.Service.Service_Id = sMan.Insert_Services(sViewModel.Service);

                sViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }
            catch (Exception ex)
            {
                sViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["pViewModel"] = pViewModel;

            //return RedirectToAction("Search");

            return View("Index", sViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(ServicesViewModel sViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    sViewModel.Service.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    sViewModel.Service.Language_Id = Convert.ToInt32(Language.ch);
                }

                sViewModel.Service.Updated_By = ((UserInfo)Session["User"]).UserId;

                sViewModel.Service.Updated_On = DateTime.Now;

                ServicesManager sMan = new ServicesManager();

                sMan.Update_Services(sViewModel.Service);

                sViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                sViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["pViewModel"] = pViewModel;

            //return RedirectToAction("Search");

            return View("Index", sViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(ServicesViewModel sViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    sViewModel.Service.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    sViewModel.Service.Language_Id = Convert.ToInt32(Language.ch);
                }

                sViewModel.Service.Updated_On = DateTime.Now;

                sViewModel.Service.Updated_By = ((UserInfo)Session["User"]).UserId;

                ServicesManager sMan = new ServicesManager();

                // this should be delete method.

                //pMan.Update_Product(pViewModel.Product);

                sViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                sViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["sViewModel"] = sViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Services_By_Id(ServicesViewModel sViewModel)
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

                ServicesManager sMan = new ServicesManager();

                sViewModel.Service = sMan.Get_Services_By_Id(sViewModel.Filter.Services_Id, language_Id);

                sViewModel.Service_Categories= sMan.Get_Services_Categories(language_Id);
            }

            catch (Exception ex)
            {
                sViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", sViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Services(ServicesViewModel sViewModel)
        {
            ServicesManager sMan = new ServicesManager();

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

                pager = sViewModel.Pager;

                sViewModel.Services = sMan.Get_Services(ref pager, language_Id);

                sViewModel.Pager = pager;

                sViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", sViewModel.Pager.TotalRecords, sViewModel.Pager.CurrentPage + 1, sViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                sViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(sViewModel, JsonRequestBehavior.AllowGet);

        }

    }
}
