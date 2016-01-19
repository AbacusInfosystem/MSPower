using MSPowerWebApp.Filters;
using MSPowerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MSPowerInfo;
using MSPowerWebApp.Common;
using MSPowerManager;
using ExceptionManagement.Logger;



namespace MSPowerWebApp.Controllers
{
    public class EnquiryController : Controller
    {
        //
        // GET: /Enquiry/

        [Language]

        public ActionResult Index(string language)
        {
            EnquiryViewModel eViewModel = new EnquiryViewModel();

            return View(eViewModel);
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(EnquiryViewModel eViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["eViewModel"] != null)
            {
                eViewModel = (EnquiryViewModel)TempData["pViewModel"];
            }

            return View("Search", eViewModel);
        }


        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        //public ActionResult Insert(EnquiryViewModel eViewModel)
        //{
        //    try
        //    {

        //        if (Session["Language"].ToString() == Language.en.ToString())
        //        {
        //            eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.en);
        //        }
        //        else
        //        {
        //            eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.ch);
        //        }

        //        eViewModel.Enquiry.Created_On = DateTime.Now;

        //        EnquiryManager eMan = new EnquiryManager();

        //        //eViewModel.Enquiry.Enquiry_Id = 1;

        //        eViewModel.Enquiry.Enquiry_Id = eMan.Insert_Enquiry(eViewModel.Enquiry);

        //        eViewModel.Friendly_Message.Add(MessageStore.Get("T011"));
        //    }

        //    catch (Exception ex)
        //    {

        //        eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Test Controller - Insert" + ex.ToString());
        //    }

        //    //TempData["eViewModel"] = eViewModel;

        //    //return RedirectToAction("Search");

        //    return View("Index", eViewModel);

        //}

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        //public ActionResult Update(EnquiryViewModel eViewModel)
        //{
        //    try
        //    {
        //        eViewModel.Enquiry.Updated_On = DateTime.Now;

        //        eViewModel.Enquiry.Updated_By = ((UserInfo)Session["User"]).UserId;

        //        EnquiryManager eMan = new EnquiryManager();

        //        eMan.Update_Enquiry(eViewModel.Enquiry);

        //        eViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
        //    }
        //    catch (Exception ex)
        //    {
        //        eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Test Controller - Update" + ex.ToString());
        //    }

        //    //TempData["eViewModel"] = eViewModel;

        //    //return RedirectToAction("Search");

        //    return View("Index", eViewModel);

        //}

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(EnquiryViewModel eViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.ch);
                }


                EnquiryManager eMan = new EnquiryManager();

                // this should be delete method.

                //eMan.Update_Enquiry(eViewModel.Enquiry);

                eViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }

            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["eViewModel"] = eViewModel;

            return View("Index", eViewModel);

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Enquiry_By_Id(EnquiryViewModel eViewModel)
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

                EnquiryManager eMan = new EnquiryManager();

                eViewModel.Enquiry = eMan.Get_Enquiry_By_Id(eViewModel.Filter.Enquiry_Id, language_Id);
            }

            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("EnquiryDetail", eViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Enquirys(EnquiryViewModel eViewModel)
        {
            EnquiryManager eMan = new EnquiryManager();

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


                pager = eViewModel.Pager;

                eViewModel.Enquirys = eMan.Get_Enquirys(ref pager, language_Id);

                eViewModel.Pager = pager;

                eViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", eViewModel.Pager.TotalRecords, eViewModel.Pager.CurrentPage + 1, eViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }

            finally
           
            {
                pager = null;
            }

            return Json(eViewModel, JsonRequestBehavior.AllowGet);

        }

    }
}
