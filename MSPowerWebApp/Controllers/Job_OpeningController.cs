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
    public class Job_OpeningController : Controller
    {

        //
        // GET: /Job_Opening/

        public Job_OpeningManager _joMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(Job_OpeningViewModel joViewModel)
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(joViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(Job_OpeningViewModel joViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["joViewModel"] != null)
            {
                joViewModel = (Job_OpeningViewModel)TempData["joViewModel"];
            }

            return View("Search", joViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(Job_OpeningViewModel joViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {

                    joViewModel.Job_Opening.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    joViewModel.Job_Opening.Language_Id = Convert.ToInt32(Language.ch);
                }

                joViewModel.Job_Opening.Created_By = ((UserInfo)Session["User"]).UserId;

                joViewModel.Job_Opening.Updated_By = ((UserInfo)Session["User"]).UserId;

                joViewModel.Job_Opening.Created_On = DateTime.Now;

                joViewModel.Job_Opening.Updated_On = DateTime.Now;

                Job_OpeningManager joMan = new Job_OpeningManager();

                //joViewModel.Job_Opening.Job_Opening_Id = 1;

                joViewModel.Job_Opening.Job_Opening_Id = joMan.Insert_Job_Opening(joViewModel.Job_Opening);

                joViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
            }
            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["joViewModel"] = joViewModel;

            //return RedirectToAction("Search");

            return View("Search", joViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(Job_OpeningViewModel joViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {

                    joViewModel.Job_Opening.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    joViewModel.Job_Opening.Language_Id = Convert.ToInt32(Language.ch);
                }

                joViewModel.Job_Opening.Updated_On = DateTime.Now;

                joViewModel.Job_Opening.Updated_By = ((UserInfo)Session["User"]).UserId;

                Job_OpeningManager joMan = new Job_OpeningManager();

                joMan.Update_Job_Opening(joViewModel.Job_Opening);

                joViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["joViewModel"] = joViewModel;

            //return RedirectToAction("Search");

            return View("Search", joViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(Job_OpeningViewModel joViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {

                    joViewModel.Job_Opening.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    joViewModel.Job_Opening.Language_Id = Convert.ToInt32(Language.ch);
                }

                joViewModel.Job_Opening.Updated_On = DateTime.Now;

                joViewModel.Job_Opening.Updated_By = ((UserInfo)Session["User"]).UserId;

                Job_OpeningManager joMan = new Job_OpeningManager();

                // this should be delete method.

                //joMan.Update_Job_Opening(joViewModel.Job_Opening);

                joViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["joViewModel"] = joViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Job_Opening_By_Id(Job_OpeningViewModel joViewModel)
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

                Job_OpeningManager joMan = new Job_OpeningManager();

                //joViewModel.Job_Opening = joMan.Get_Job_Opening_By_Id(joViewModel.Job_Opening.Job_Opening_Id);

                joViewModel.Job_Opening = joMan.Get_Job_Opening_By_Id(joViewModel.Filter.Job_Opening_Id, language_Id);
            }

            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", joViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Job_Openings(Job_OpeningViewModel joViewModel)
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

            return Json(joViewModel, JsonRequestBehavior.AllowGet);

        }

    }
}