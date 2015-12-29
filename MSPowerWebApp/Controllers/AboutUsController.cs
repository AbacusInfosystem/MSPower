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
    public class AboutUsController : Controller
    {
        //
        // GET: /AboutUs/

        public AboutUsManager _auMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(AboutUsViewModel auViewModel)
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(auViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(AboutUsViewModel auViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["auViewModel"] != null)
            {
                auViewModel = (AboutUsViewModel)TempData["auViewModel"];
            }

            return View("Search", auViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(AboutUsViewModel auViewModel)
        {
            try
            {
                auViewModel.AboutUs.Created_By = ((UserInfo)Session["User"]).UserId;

                auViewModel.AboutUs.Updated_By = ((UserInfo)Session["User"]).UserId;

                auViewModel.AboutUs.Created_On = DateTime.Now;

                auViewModel.AboutUs.Updated_On = DateTime.Now;

                AboutUsManager auMan = new AboutUsManager();

                //auViewModel.AboutUs.AboutUs_Id = 1;

                auViewModel.AboutUs.About_Us_Id = auMan.Insert_AboutUs(auViewModel.AboutUs);

                auViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }
            catch (Exception ex)
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["auViewModel"] = auViewModel;

            //return RedirectToAction("Search");

            return View("Index", auViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(AboutUsViewModel auViewModel)
        {
            try
            {
                auViewModel.AboutUs.Updated_On = DateTime.Now;

                auViewModel.AboutUs.Updated_By = ((UserInfo)Session["User"]).UserId;

                AboutUsManager auMan = new AboutUsManager();

                auMan.Update_AboutUs(auViewModel.AboutUs);

                auViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["auViewModel"] = auViewModel;

            //return RedirectToAction("Search");

            return View("Index", auViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(AboutUsViewModel auViewModel)
        {
            try
            {
                auViewModel.AboutUs.Updated_On = DateTime.Now;

                auViewModel.AboutUs.Updated_By = ((UserInfo)Session["User"]).UserId;

                AboutUsManager auMan = new AboutUsManager();

                // this should be delete method.

                //auMan.Update_AboutUs(auViewModel.AboutUs);

                auViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }

            catch (Exception ex)
            
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["auViewModel"] = auViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_AboutUs_By_Id(AboutUsViewModel auViewModel)
        {
            try
            {
                AboutUsManager auMan = new AboutUsManager();

                auViewModel.AboutUs = auMan.Get_AboutUs_By_Id(auViewModel.Filter.About_Us_Id);
            }

            catch (Exception ex)
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", auViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_AboutUss(AboutUsViewModel auViewModel)
        {
            AboutUsManager auMan = new AboutUsManager();

            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = auViewModel.Pager;

                auViewModel.AboutUss = auMan.Get_AboutUss(ref pager);

                auViewModel.Pager = pager;

                auViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", auViewModel.Pager.TotalRecords, auViewModel.Pager.CurrentPage + 1, auViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(auViewModel, JsonRequestBehavior.AllowGet);

        }

    }
}
