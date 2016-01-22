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
    public class ServiceCategoryController : Controller
    {
        public ServiceCategoryManager _scMan;

        // IF USER CLICKS ON CREATE BUTTON, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Index(ServiceCategoryViewModel scViewModel)
        {
            _scMan = new ServiceCategoryManager();

            ViewBag.Title = "MS POWER ERP :: Create, Update";

            return View(scViewModel);
        }

        [HttpPost]

        public ActionResult Upload(ServiceCategoryViewModel scViewModel)
        {


            if (scViewModel.Upload_File != null && scViewModel.Upload_File.ContentLength > 0)
                try
                {
                    if ((Path.GetExtension(scViewModel.Upload_File.FileName) == ".jpeg") || (Path.GetExtension(scViewModel.Upload_File.FileName) == ".jpg") || (Path.GetExtension(scViewModel.Upload_File.FileName) == ".png"))
                    {
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath2"]).ToString(), scViewModel.ServiceCategory.Service_Category_Id.ToString());

                        if (!System.IO.Directory.Exists(path))
                        {
                            System.IO.Directory.CreateDirectory(path);
                        }
                        else
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(path);

                            foreach (FileInfo file in di.GetFiles())
                            {
                                file.Delete();
                            }
                        }

                        path = Path.Combine(path, Path.GetFileName(scViewModel.Upload_File.FileName));

                        scViewModel.Upload_File.SaveAs(path);

                        scViewModel.Friendly_Message.Add(MessageStore.Get("IU001"));

                        ViewBag.Message = "File uploaded successfully";
                    }
                    else
                    {
                        scViewModel.Friendly_Message.Add(MessageStore.Get("IU003"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug(ex.StackTrace);
                }
            else
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("IU002"));
            }

            TempData["Service_Category_Id"] = scViewModel.ServiceCategory.Service_Category_Id;

            return RedirectToAction("Get_Service_Category_By_Id");
        }

        public JsonResult GetImages(int servicecategory_Id)
        {
            ServiceCategoryViewModel scViewModel = new ServiceCategoryViewModel();

            // Process the list of files found in the directory.

            string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath2"]).ToString(), servicecategory_Id.ToString());

            if (System.IO.Directory.Exists(path))
            {
                string[] fileEntries = Directory.GetFiles(path);

                foreach (string fileName in fileEntries)
                {
                    scViewModel.File_Name.Add(Path.GetFileName(fileName));
                }
            }

            return Json(scViewModel, JsonRequestBehavior.AllowGet);
        }

        public void DeleteImage(string imageName, int servicecategory_Id)
        {
            ServiceCategoryViewModel scViewModel = new ServiceCategoryViewModel();

            string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath2"]).ToString(), servicecategory_Id.ToString(), imageName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(ServiceCategoryViewModel scViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["scViewModel"] != null)
            {
                scViewModel = (ServiceCategoryViewModel)TempData["scViewModel"];
            }

            return View("Search", scViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(ServiceCategoryViewModel scViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    scViewModel.ServiceCategory.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    scViewModel.ServiceCategory.Language_Id = Convert.ToInt32(Language.ch);
                }

                scViewModel.ServiceCategory.Created_By = ((UserInfo)Session["User"]).UserId;

                scViewModel.ServiceCategory.Updated_By = ((UserInfo)Session["User"]).UserId;

                scViewModel.ServiceCategory.Created_On = DateTime.Now;

                scViewModel.ServiceCategory.Updated_On = DateTime.Now;

                ServiceCategoryManager scMan = new ServiceCategoryManager();

                //pViewModel.Product.Product_Id = 1;

                scViewModel.ServiceCategory.Service_Category_Id = scMan.Insert_Service_Category(scViewModel.ServiceCategory);

                scViewModel.Friendly_Message.Add(MessageStore.Get("P001"));
            }
            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["pViewModel"] = pViewModel;

            //return RedirectToAction("Search");

            return View("Index", scViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(ServiceCategoryViewModel scViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    scViewModel.ServiceCategory.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    scViewModel.ServiceCategory.Language_Id = Convert.ToInt32(Language.ch);
                }

                scViewModel.ServiceCategory.Updated_By = ((UserInfo)Session["User"]).UserId;

                scViewModel.ServiceCategory.Updated_On = DateTime.Now;

                ServiceCategoryManager scMan = new ServiceCategoryManager();

                scMan.Update_Service_Categories(scViewModel.ServiceCategory);

                scViewModel.Friendly_Message.Add(MessageStore.Get("S002"));
            }
            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            //TempData["pViewModel"] = pViewModel;

            //return RedirectToAction("Search");

            return View("Index", scViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Delete(ServiceCategoryViewModel scViewModel)
        {
            try
            {

                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    scViewModel.ServiceCategory.Language_Id = Convert.ToInt32(Language.en);
                }
                else
                {
                    scViewModel.ServiceCategory.Language_Id = Convert.ToInt32(Language.ch);
                }

                scViewModel.ServiceCategory.Updated_On = DateTime.Now;

                scViewModel.ServiceCategory.Updated_By = ((UserInfo)Session["User"]).UserId;

                ServiceCategoryManager scMan = new ServiceCategoryManager();

                // this should be delete method.

                //pMan.Update_Product(pViewModel.Product);

                scViewModel.Friendly_Message.Add(MessageStore.Get("T012"));
            }
            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["scViewModel"] = scViewModel;

            return View("Search");

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Service_Category_By_Id(ServiceCategoryViewModel scViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {

                if (TempData["Service_Category_Id"] != null)
                {
                    scViewModel.Filter.Service_Category_Id = (int)TempData["Service_Category_Id"];
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

                pager = scViewModel.Pager;

                ServiceCategoryManager scMan = new ServiceCategoryManager();

                scViewModel.ServiceCategory = scMan.Get_Service_Category_By_Id(scViewModel.Filter.Service_Category_Id, language_Id);

                scViewModel.ServiceCategories = scMan.Get_Services_Categories(ref pager, language_Id);

            }

            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", scViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCTS FROM DB.

        public JsonResult Get_Services_Categories(ServiceCategoryViewModel scViewModel)
        {
            ServiceCategoryManager scMan = new ServiceCategoryManager();

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

                pager = scViewModel.Pager;

                scViewModel.ServiceCategories = scMan.Get_Services_Categories(ref pager, language_Id);

                scViewModel.Pager = pager;

                scViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", scViewModel.Pager.TotalRecords, scViewModel.Pager.CurrentPage + 1, scViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return Json(scViewModel, JsonRequestBehavior.AllowGet);

        }

    }
}

