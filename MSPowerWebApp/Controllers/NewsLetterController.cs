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
    public class NewsLetterController : Controller
    {
        //
        // GET: /NewLetter/

        public NewsLetterManager _nlMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(NewsLetterViewModel nlViewModel)
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(nlViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(NewsLetterViewModel nlViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["nlViewModel"] != null)
            {
                nlViewModel = (NewsLetterViewModel)TempData["nlViewModel"];
            }

            return View("Search", nlViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(NewsLetterViewModel nlViewModel)
        {
            try
            {
                nlViewModel.NewsLetter.Created_By = ((UserInfo)Session["User"]).UserId;

                nlViewModel.NewsLetter.Updated_By = ((UserInfo)Session["User"]).UserId;

                nlViewModel.NewsLetter.Created_On = DateTime.Now;

                nlViewModel.NewsLetter.Updated_On = DateTime.Now;

                nlViewModel.NewsLetter.NewLetter_Release_Date = DateTime.Now;

                NewsLetterManager nlMan = new NewsLetterManager();

                //nlViewModel.NewsLetter.NewsLetter_Id = 1;

                nlViewModel.NewsLetter.NewsLetter_Id = nlMan.Insert_NewsLetter(nlViewModel.NewsLetter);

                nlViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }
            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["nlViewModel"] = nlViewModel;

            //return RedirectToAction("Search");

            return View("Index", nlViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(NewsLetterViewModel nlViewModel)
        {
            try
            {
                nlViewModel.NewsLetter.Updated_On = DateTime.Now;

                nlViewModel.NewsLetter.NewLetter_Release_Date = DateTime.Now;

                nlViewModel.NewsLetter.Updated_By = ((UserInfo)Session["User"]).UserId;

                NewsLetterManager nlMan = new NewsLetterManager();

                nlMan.Update_NewsLetter(nlViewModel.NewsLetter);

                nlViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["nlViewModel"] = nlViewModel;

            //return RedirectToAction("Search");

            return View("Index", nlViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(NewsLetterViewModel nlViewModel)
        {
            try
            {
                nlViewModel.NewsLetter.Updated_On = DateTime.Now;

                nlViewModel.NewsLetter.Updated_By = ((UserInfo)Session["User"]).UserId;

                NewsLetterManager nlMan = new NewsLetterManager();

                // this should be delete method.

                //nlMan.Update_NewsLetter(nlViewModel.NewsLetter);

                nlViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["nlViewModel"] = nlViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_NewsLetter_By_Id(NewsLetterViewModel nlViewModel)
        {
            try
            {
                NewsLetterManager nlMan = new NewsLetterManager();

                nlViewModel.NewsLetter = nlMan.Get_NewsLetter_By_Id(nlViewModel.Filter.NewsLetter_Id);
            }

            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", nlViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_NewsLetters(NewsLetterViewModel nlViewModel)
        {
            NewsLetterManager nlMan = new NewsLetterManager();

            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = nlViewModel.Pager;

                nlViewModel.NewsLetters = nlMan.Get_NewsLetters(ref pager);

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

            return Json(nlViewModel, JsonRequestBehavior.AllowGet);

        }
    }
}
