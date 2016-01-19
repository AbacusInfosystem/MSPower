using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Configuration;
using MSPowerInfo;
using MSPowerWebApp.Common;
using MSPowerWebApp.Models;
using MSPowerManager;
using ExceptionManagement.Logger;

namespace MSPowerWebApp.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        public EventManager _eMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.



        public ActionResult Index(EventViewModel eViewModel)
        {

            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(eViewModel);
        }


        [HttpPost]

        public ActionResult Upload(EventViewModel eViewModel)
        {


            if (eViewModel.Upload_File != null && eViewModel.Upload_File.ContentLength > 0)
                try
                {
                    if ((Path.GetExtension(eViewModel.Upload_File.FileName) == ".jpeg") || (Path.GetExtension(eViewModel.Upload_File.FileName) == ".jpg") || (Path.GetExtension(eViewModel.Upload_File.FileName) == ".png"))
                    {
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath1"]).ToString(), eViewModel.Event.Event_Id.ToString());

                        if (!System.IO.Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }

                       path = Path.Combine(path, Path.GetFileName(eViewModel.Upload_File.FileName));

                        eViewModel.Upload_File.SaveAs(path);

                        eViewModel.Friendly_Message.Add(MessageStore.Get("IU001"));

                        ViewBag.Message = "File uploaded successfully";
                    }
                    else
                    {
                        eViewModel.Friendly_Message.Add(MessageStore.Get("IU003"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug(ex.StackTrace);
                }
            else
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("IU002"));
            }

            TempData["Event_Id"] = eViewModel.Event.Event_Id;

            return RedirectToAction("Get_Event_By_Id");
        }


        public JsonResult GetImages(int event_Id)
        {
            EventViewModel eViewModel = new EventViewModel();

            // Process the list of files found in the directory.

            string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath1"]).ToString(), event_Id.ToString());

            if (System.IO.Directory.Exists(path))
            {
                string[] fileEntries = Directory.GetFiles(path);

                foreach (string fileName in fileEntries)
                {
                    eViewModel.File_Name.Add(Path.GetFileName(fileName));
                }
            }

            return Json(eViewModel, JsonRequestBehavior.AllowGet);
        }

        public void DeleteImage(string imageName, int event_Id)
        {
            EventViewModel eViewModel = new EventViewModel();

            string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath1"]).ToString(), event_Id.ToString(), imageName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }




        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(EventViewModel eViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["eViewModel"] != null)
            {
                eViewModel = (EventViewModel)TempData["eViewModel"];
            }

            return View("Search", eViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(EventViewModel eViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    eViewModel.Event.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    eViewModel.Event.Language_Id = Convert.ToInt32(Language.ch);
                }

                eViewModel.Event.Created_By = ((UserInfo)Session["User"]).UserId;

                eViewModel.Event.Updated_By = ((UserInfo)Session["User"]).UserId;

                eViewModel.Event.Created_On = DateTime.Now;

                eViewModel.Event.Updated_On = DateTime.Now;

                EventManager eMan = new EventManager();

                //eViewModel.Event.Event_Id = 1;

                eViewModel.Event.Event_Id = eMan.Insert_Event(eViewModel.Event);

                eViewModel.Friendly_Message.Add(MessageStore.Get("E001"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["eViewModel"] = eViewModel;

            //return RedirectToAction("Search");

            return View("Index", eViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(EventViewModel eViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    eViewModel.Event.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    eViewModel.Event.Language_Id = Convert.ToInt32(Language.ch);
                }

                eViewModel.Event.Updated_On = DateTime.Now;

                eViewModel.Event.Updated_By = ((UserInfo)Session["User"]).UserId;

                EventManager eMan = new EventManager();

                eMan.Update_Event(eViewModel.Event);

                eViewModel.Friendly_Message.Add(MessageStore.Get("E002"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["eViewModel"] = eViewModel;

            //return RedirectToAction("Search");

            return View("Index", eViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(EventViewModel eViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    eViewModel.Event.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    eViewModel.Event.Language_Id = Convert.ToInt32(Language.ch);
                }

                eViewModel.Event.Updated_On = DateTime.Now;

                eViewModel.Event.Updated_By = ((UserInfo)Session["User"]).UserId;

                EventManager eMan = new EventManager();

                // this should be delete method.

                //eMan.Update_Event(eViewModel.Event);

                eViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["eViewModel"] = eViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Event_By_Id(EventViewModel eViewModel)
        {
            try
            {
                if(TempData["Event_Id"]  != null)
                {
                    eViewModel.Filter.Event_Id = (int)TempData["Event_Id"];
                }

                int language_Id = 0;

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    language_Id = Convert.ToInt32(Language.ch);
                }

                EventManager eMan = new EventManager();

                eViewModel.Event = eMan.Get_Event_By_Id(eViewModel.Filter.Event_Id, language_Id);
            }

            catch (Exception ex)
            {
                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", eViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Events(EventViewModel eViewModel)
        {
            EventManager eMan = new EventManager();

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

                eViewModel.Events = eMan.Get_Events(ref pager, language_Id);

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
