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
    public class ContactUsController : Controller
    {
        //
        // GET: /ContactUs/

        public ContactUsManager _cuMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(ContactUsViewModel cuViewModel)
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(cuViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(ContactUsViewModel cuViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["cuViewModel"] != null)
            {
                cuViewModel = (ContactUsViewModel)TempData["cuViewModel"];
            }

            return View("Search", cuViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(ContactUsViewModel cuViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    cuViewModel.ContactUs.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    cuViewModel.ContactUs.Language_Id = Convert.ToInt32(Language.ch);
                }

                cuViewModel.ContactUs.Created_By = ((UserInfo)Session["User"]).UserId;

                cuViewModel.ContactUs.Updated_By = ((UserInfo)Session["User"]).UserId;

                cuViewModel.ContactUs.Created_On = DateTime.Now;

                cuViewModel.ContactUs.Updated_On = DateTime.Now;

                ContactUsManager cuMan = new ContactUsManager();

                //cuViewModel.ContactUs.ContactUs_Id = 1;

                cuViewModel.ContactUs.ContactUs_Id = cuMan.Insert_ContactUs(cuViewModel.ContactUs);

                cuViewModel.Friendly_Message.Add(MessageStore.Get("C001"));
            }

            catch (Exception ex)
            
            {
                cuViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["cuViewModel"] = cuViewModel;

            //return RedirectToAction("Search");

            return View("Index", cuViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(ContactUsViewModel cuViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    cuViewModel.ContactUs.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    cuViewModel.ContactUs.Language_Id = Convert.ToInt32(Language.ch);
                }

                cuViewModel.ContactUs.Updated_On = DateTime.Now;

                cuViewModel.ContactUs.Updated_By = ((UserInfo)Session["User"]).UserId;

                ContactUsManager cuMan = new ContactUsManager();

                cuMan.Update_ContactUs(cuViewModel.ContactUs);

                cuViewModel.Friendly_Message.Add(MessageStore.Get("C002"));
            }
            catch (Exception ex)
            {
                cuViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["cuViewModel"] = cuViewModel;

            //return RedirectToAction("Search");

            return View("Index", cuViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(ContactUsViewModel cuViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    cuViewModel.ContactUs.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    cuViewModel.ContactUs.Language_Id = Convert.ToInt32(Language.ch);
                }

                cuViewModel.ContactUs.Updated_On = DateTime.Now;

                cuViewModel.ContactUs.Updated_By = ((UserInfo)Session["User"]).UserId;

                ContactUsManager cuMan = new ContactUsManager();

                // this should be delete method.

                //cuMan.Update_ContactUs(cuViewModel.ContactUs);

                cuViewModel.Friendly_Message.Add(MessageStore.Get("T012"));

            }
            catch (Exception ex)
            {
                cuViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["cuViewModel"] = cuViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_ContactUs_By_Id(ContactUsViewModel cuViewModel)
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

                ContactUsManager cuMan = new ContactUsManager();

                cuViewModel.ContactUs = cuMan.Get_ContactUs_By_Id(cuViewModel.Filter.ContactUs_Id, language_Id);
            }

            catch (Exception ex)
            {
                cuViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", cuViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_ContactUss(ContactUsViewModel cuViewModel)
        {
            ContactUsManager cuMan = new ContactUsManager();

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

                pager = cuViewModel.Pager;

                cuViewModel.ContactUss = cuMan.Get_ContactUss(ref pager, language_Id);

                cuViewModel.Pager = pager;

                cuViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", cuViewModel.Pager.TotalRecords, cuViewModel.Pager.CurrentPage + 1, cuViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                cuViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(cuViewModel, JsonRequestBehavior.AllowGet);

        }

    }
}
