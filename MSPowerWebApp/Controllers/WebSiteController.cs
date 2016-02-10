using ExceptionManagement.Logger;
using MSPowerInfo;
using MSPowerManager;
using MSPowerWebApp.Common;
using MSPowerWebApp.Filters;
using MSPowerWebApp.Models;
using System;

using System.Drawing;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;

namespace MSPowerWebApp.Controllers
{
    public class WebSiteController : Controller
    {
        //
        // GET: /WebSite/

        [Language]

        public ActionResult Index(string language)
        {
            return View();
        }

        [Language]

        //public ActionResult ProductListing(string language, int product_Category_Id, string Col1, string competitor)

        public ActionResult ProductListing(string language, int product_Category_Id, string keyword, string competitor)
        {
            ProductDetailViewModel pViewModel = new ProductDetailViewModel();

            ProductDetailsManager _pMan = new ProductDetailsManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }
             
            try
            {
                //pViewModel.Product_Categories = _pMan.Get_Product_Categories_By_Lanugae_Id(language_Id);

                pViewModel.Language_Id = language_Id;

                if (product_Category_Id != 0)
                {
                    pViewModel.Product_Category = _pMan.Get_Product_Category_By_Id(product_Category_Id, language_Id);

                    pViewModel.Volts = _pMan.Get_Product_Volts(product_Category_Id);

                    //if(pViewModel.Volts.Count>0)
                    //{
                    //    product_Category_Id = 0;
                    //}
                }

                //else if (!string.IsNullOrEmpty(keyword))
                //{
                //    //pViewModel.Volts.Add(_pMan.Get_Product_Detail_By_Name(Col1));
                //}
            }
            catch (Exception ex)
            {
                pViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("WebSite Controller - ProductListing" + ex.ToString());
            }

            //if (product_Category_Id != 0)
            //{
            //    return View(pViewModel);
            //}


            if ((product_Category_Id == 0 && string.IsNullOrEmpty(competitor) && string.IsNullOrEmpty(keyword)) || (pViewModel.Volts.Count == 0 && (competitor == "_" || string.IsNullOrEmpty(competitor)) && (keyword == "_" || string.IsNullOrEmpty(keyword)))) //if (pViewModel.Volts.Count == 0)
            {
                return View(pViewModel);
            }
            else
            {
                if (product_Category_Id != 0)
                {
                    return RedirectToAction("Product", new System.Web.Routing.RouteValueDictionary { { "language", language }, { "product_Category_Id", pViewModel.Product_Category.Product_Category_Id } });
                }
                else if (competitor == "_" && keyword != "_")
                {
                    return RedirectToAction("Get_Product_Detail_By_Name", new System.Web.Routing.RouteValueDictionary { { "language", language }, { "Col1", keyword } });
                }
                else //(keyword == "_" && competitor != "_")
                {
                    return RedirectToAction("Get_Product_Detail_By_Competitor_Name", new System.Web.Routing.RouteValueDictionary { { "language", language }, { "competitor", competitor } });
                }
            }
        }

        public ActionResult Product(string language, int product_Category_Id)
        {
            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            ProductDetailsManager pdMan = new ProductDetailsManager();

            PaginationInfo pager = new PaginationInfo();

            if (Language.en.ToString() == language)
            {
                pdViewModel.Language_Id = (int)Language.en;
            }
            else
            {
                pdViewModel.Language_Id = (int)Language.ch;
            }

            pager.IsPagingRequired = false;

            try
            {
                pdViewModel.Product_Category = pdMan.Get_Product_Category_By_Id(product_Category_Id, pdViewModel.Language_Id);

                pdViewModel.Volts = pdMan.Get_Product_Volts(pdViewModel.Product_Category.Product_Category_Id);

                foreach (var item in pdViewModel.Volts)
                {
                    item.Product_Details_Header = pdMan.Get_Product_Details_Header(item.Product_Column_Ref_Id);

                    item.Product_Details = pdMan.Get_Product_Details_By_Col(ref pager, item.Product_Category_Column_Mapping_Id, item.Product_Column_Ref_Id,item.Col_Filter);
                    
                    foreach (var itm in item.Product_Details)
                    {
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), itm.Col1 + ".pdf");

                        if (System.IO.File.Exists(path))
                        {
                            itm.Is_PDF_Exists = true;
                        }
                        else
                        {
                            itm.Is_PDF_Exists = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("WebSite Controller - Product" + ex.ToString());
            }

            return View(pdViewModel);
        }

        [Language]

        public ActionResult ServiceListing(string language)
        {
            ServiceCategoryViewModel scViewModel = new ServiceCategoryViewModel();

            ServiceCategoryManager _scMan = new ServiceCategoryManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            try
            {
                scViewModel.ServiceCategories = _scMan.Get_Service_Categories_By_Language_Id(language_Id);

                scViewModel.Language = language;
            }
            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("WebSite Controller - ProductListing" + ex.ToString());
            }

            return View(scViewModel);
        }

        [Language]

        public ActionResult Service(string language, int Service_Category_Id)
        {
            ServiceCategoryViewModel scViewModel = new ServiceCategoryViewModel();

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

                ServiceCategoryManager _scMan = new ServiceCategoryManager();

                scViewModel.ServiceCategory = _scMan.Get_Services_Categories_By_Id(Service_Category_Id, language_Id);
            }

            catch (Exception ex)
            {
                scViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Service", scViewModel);
        }

        [Language]

        public ActionResult NewsLetterListing(string language)
        {
            NewsLetterViewModel nlViewModel = new NewsLetterViewModel();

            NewsLetterManager nlMan = new NewsLetterManager();

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

                pager = nlViewModel.Pager;

                nlViewModel.NewsLetters = nlMan.Get_NewsLetters(ref pager, language_Id);

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

            return View(nlViewModel);

        }

        public ActionResult Get_NewsLetter_By_Id(int NewsLetter_Id)
        {

            NewsLetterViewModel nlViewModel = new NewsLetterViewModel();

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

                NewsLetterManager nlMan = new NewsLetterManager();

                nlViewModel.NewsLetter = nlMan.Get_NewsLetter_By_Id(NewsLetter_Id, language_Id);
            }

            catch (Exception ex)
            {
                nlViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("NewsLetter", nlViewModel);
        }

        [Language]

        public ActionResult ContactUsListing(string language)
        {
            return View();
        }

        [Language]

        public ActionResult ContactUs(string language)
        {
            ContactUsViewModel cViewModel = new ContactUsViewModel();

            ContactUsManager _cMan = new ContactUsManager();

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            int language_Id = 0;

            if (Session["Language"].ToString() == Language.en.ToString())
            {
                language_Id = Convert.ToInt32(Language.en);
            }
            else
            {
                language_Id = Convert.ToInt32(Language.ch);
            }

            try
            {
                cViewModel.ContactUss = _cMan.Get_ContactUss(ref pager,language_Id);
            }
            catch(Exception ex)
            {
                cViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            return View(cViewModel);
        }

        [Language]

        public ActionResult AboutUs(string language)
        {
            AboutUsViewModel auViewModel = new AboutUsViewModel();

            AboutUsManager auMan = new AboutUsManager();

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

                auViewModel.AboutUs = auMan.Get_AboutUs(language_Id);

            }
            catch (Exception ex)
            {
                auViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {

            }

            return View(auViewModel);

        }

        [Language]

        public ActionResult Job_OpeningListing(string language)
        {
            Job_OpeningViewModel joViewModel = new Job_OpeningViewModel();

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

            return View(joViewModel);

        }


        public ActionResult Get_Job_Opening_By_Id(int Job_Opening_Id)
        {
            Job_OpeningViewModel joViewModel = new Job_OpeningViewModel();

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

                joViewModel.Job_Opening = joMan.Get_Job_Opening_By_Id(Job_Opening_Id, language_Id);
            }

            catch (Exception ex)
            {
                joViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Job_Opening", joViewModel);
        }

        [Language]

        public ActionResult Job_Application(string language)
        {
            Job_ApplicationViewModel jaViewModel = new Job_ApplicationViewModel();

            if (Session["Language"].ToString() == Language.en.ToString())
            {
                jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.en);
            }

            else
            {
                jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.ch);
            }

            return View(jaViewModel);

        }

        [Language]

        [HttpPost]

        public ActionResult Insert_Job_Application(Job_ApplicationViewModel jaViewModel)
        {
            try
            {
                if (Session["Language"].ToString() == Language.en.ToString())
                {
                    jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.en);
                }

                else
                {
                    jaViewModel.Job_Application.Language_Id = Convert.ToInt32(Language.ch);
                }

                jaViewModel.Job_Application.Created_On = DateTime.Now;

                if (this.IsCaptchaValid("Captcha is not valid"))
                {

                    Job_ApplicationManager jaMan = new Job_ApplicationManager();

                    //jaViewModel.Job_Application.Job_Application_Id = 1;

                    jaViewModel.Job_Application.Job_Application_Id = jaMan.Insert_Job_Application(jaViewModel.Job_Application);

                    DocxUpload(jaViewModel.Upload_File, jaViewModel.Job_Application.Job_Application_Id.ToString());

                    jaViewModel.Friendly_Message.Add(MessageStore.Get("T011"));

                    //return RedirectToAction("Job_Application");

                    return RedirectToAction("Job_Application", new { language = Session["Language"].ToString() });
                }

                    ViewBag.ErrMessage = "Error: captcha is not valid.";

            }

                catch (Exception ex)

                {
                    jaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                    Logger.Error("Test Controller - Insert" + ex.ToString());
                }

                //TempData["jaViewModel"] = jaViewModel;

                //return RedirectToAction("Search");

               

                string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), jaViewModel.Job_Application.Job_Application_Id + ".docx");

                if (jaViewModel.Job_Application.Job_Application_Id != 0)
                {
                    if (System.IO.File.Exists(path))
                    {
                        jaViewModel.Is_DOCX_Exists = true;
                    }
                    else
                    {
                        jaViewModel.Is_DOCX_Exists = false;
                    }
                }

                TempData["jaViewModel"] = jaViewModel;

                return View("Job_Application", jaViewModel);

            }

        [Language]

        public void DocxUpload(HttpPostedFileBase file, string id)
        {
            Job_ApplicationViewModel jaViewModel = new Job_ApplicationViewModel();

            if (file != null && file.ContentLength > 0)
                try
                {
                    if ((Path.GetExtension(file.FileName) == ".docx"))
                    {
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), id + ".docx");

                        System.IO.File.Delete(path);

                        file.SaveAs(path);

                        ViewBag.Message = "File uploaded successfully";
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug(ex.StackTrace);
                }
        }

        public FileResult Download_Job_Application_Details_DOCX(int job_application_Id)
        {
            string path = "";

            try
            {
                path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ResumeUploadPath"]).ToString(), job_application_Id + ".docx");
            }
            catch (Exception ex)
            {
                Logger.Error("Job Application Details Controller - Download_Job_Application_Details_DOCX" + ex.ToString());
            }

            return File(path, "application/docx", "Job Application Details.docx");
        }

        public PartialViewResult Get_Product_Search(string language)
        {
            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            ProductDetailsManager _pMan = new ProductDetailsManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            try
            {
                pdViewModel.Product_Categories = _pMan.Get_Product_Categories_By_Lanugae_Id(language_Id);

                pdViewModel.Language = language;
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Web Site Controller - Get_Product_Details" + ex.ToString());
            }

            return PartialView("_Product_Search", pdViewModel);
        }

        [Language]

        public ActionResult Events(string language)
        {
            EventViewModel eViewModel = new EventViewModel();

            EventManager _eMan = new EventManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = true;

            try
            {
                eViewModel.Events = _eMan.Get_Events(ref pager, language_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("Web Site Controller - Events" + ex.ToString());
            }

            return View("Events", eViewModel);
        }

        public PartialViewResult Get_Events_Images(int event_Id)
        {
            EventViewModel eViewModel = new EventViewModel();

            eViewModel.Event.Event_Id = event_Id;

            try
            {
                string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath1"]).ToString(), event_Id.ToString());

                if (System.IO.Directory.Exists(path))
                {
                    string[] fileEntries = Directory.GetFiles(path);

                    foreach (string fileName in fileEntries)
                    {
                        eViewModel.File_Name.Add(Path.GetFileName(fileName));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Web Site Controller - Get_Events_Images" + ex.ToString());
            }

            return PartialView("_Events_Images", eViewModel);
        }

        public ActionResult SetLanguage(string language)
        {
            try
            {
                Session["Language"] = language;
            }
            catch (Exception ex)
            {
                Logger.Error("Web Site Controller - Get_Events_Images" + ex.ToString());
            }
            return RedirectToAction("Index");
        }

        [Language]

        public ActionResult Enquiry(string language)
        {
            EnquiryViewModel eViewModel = new EnquiryViewModel();

            if (Session["Language"].ToString() == Language.en.ToString())
            {
                eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.en);
            }

            else
            {
                eViewModel.Enquiry.Language_Id = Convert.ToInt32(Language.ch);
            }

            return View(eViewModel);
        }

        [Language]

        [HttpPost]

        public ActionResult Insert_Enquiry(string language, EnquiryViewModel eViewModel)
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

                eViewModel.Enquiry.Created_On = DateTime.Now;

                if (this.IsCaptchaValid("Captcha is not valid"))
                {

                EnquiryManager eMan = new EnquiryManager();

                eMan.Insert_Enquiry(eViewModel.Enquiry);

                //eViewModel.Friendly_Message.Add(MessageStore.Get("T011"));

                //return RedirectToAction("Enquiry","WebSite", new System.Web.Routing.RouteValueDictionary { { "language", language }});

                return RedirectToAction("Enquiry", new { language = Session["Language"].ToString() });

                }

                 ViewBag.ErrMessage = "Error: captcha is not valid.";
            }

            catch (Exception ex)
            {

                eViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            return View("Enquiry", eViewModel);

        }

        public JsonResult Get_AboutUs(string language)
        {
            AboutUsViewModel aViewModel = new AboutUsViewModel();

            AboutUsManager auMan = new AboutUsManager();

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

                aViewModel.AboutUs = auMan.Get_AboutUs(language_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("WebApp Controller - Get_AboutUs" + ex.ToString());
            }

            return Json(aViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_NewsLetters(string language)
        {
            NewsLetterManager nlMan = new NewsLetterManager();

            PaginationInfo pager = new PaginationInfo();

            NewsLetterViewModel nlViewModel = new NewsLetterViewModel();

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

                pager = nlViewModel.Pager;

               // pager.PageSize = 1; // as Per requirement display only one record on landing page 

                nlViewModel.NewsLetters = nlMan.Get_NewsLetters_Active(ref pager, language_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("WebApp Controller - Get_AboutUs" + ex.ToString());
            }

            return Json(nlViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Hot_Jobs(string language)
        {
            Job_OpeningViewModel joViewModel = new Job_OpeningViewModel();

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

            }
            catch (Exception ex)
            {
                Logger.Error("WebApp Controller - Get_Hot_Jobs" + ex.ToString());
            }

            return Json(joViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Events(string language)
        {
            EventViewModel eViewModel = new EventViewModel();

            EventManager _eMan = new EventManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            PaginationInfo pager = new PaginationInfo();

            try
            {
                eViewModel.Events = _eMan.Get_Events(ref pager, language_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("WebApp Controller - Get_AboutUs" + ex.ToString());
            }

            return Json(eViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Genrated_Html_Product_Categories(int language_Id, int parent_Category_Id)
        {
            string html = "";

            ProductDetailsManager _pMan = new ProductDetailsManager();

            try
            {
                html = _pMan.Genrate_Html_For_Product_Categories(language_Id, parent_Category_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("WebApp Controller - Get_Genrated_Html_Product_Categories" + ex.ToString());
            }

            return Json(html, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Genrated_Html_Product_Categories_Images(int language_Id, int parent_Category_Id)
        {
            string html = "";

            ProductDetailsManager _pMan = new ProductDetailsManager();

            try
            {
                html = _pMan.Genrate_Html_For_Product_Categories_Images(language_Id, parent_Category_Id);
            }
            catch (Exception ex)
            {
                Logger.Error("WebApp Controller - Get_Genrated_Html_Product_Categories_Images" + ex.ToString());
            }

            return Json(html, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult Get_Product_By_Product_Category_Id(int language_Id, int product_Category_Id)
        //{
        //    ProductDetailsManager _pMan = new ProductDetailsManager();

        //    ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

        //    try
        //    {
        //       pdViewModel.Volts = _pMan.Get_Product_Volts(product_Category_Id);

        //        if(pdViewModel.Volts.Count == 0)
        //        {
        //            pdViewModel.Product_Category.Product_Category_Id = product_Category_Id;
        //        }

        //        pdViewModel.Language_Id = language_Id;
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.Error("WebApp Controller - Get_Product_By_Product_Category_Id" + ex.ToString());
        //    }

        //    return View();
        //}

        public JsonResult Get_Product_Volts(ProductDetailViewModel pdViewModel)
        {
            ProductDetailsManager pdMan = new ProductDetailsManager();

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false; 

            try
            {
                pdViewModel.Volt.Product_Details_Header = pdMan.Get_Product_Details_Header(pdViewModel.Volt.Product_Column_Ref_Id);

                pdViewModel.Volt.Product_Details = pdMan.Get_Product_Details_By_Col(ref pager, pdViewModel.Volt.Product_Category_Column_Mapping_Id, pdViewModel.Volt.Product_Column_Ref_Id, pdViewModel.Volt.Col_Filter);

                foreach (var itm in pdViewModel.Volt.Product_Details)
                {
                    string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), itm.Col1 + ".pdf");

                    if (System.IO.File.Exists(path))
                    {
                        itm.Is_PDF_Exists = true;
                    }
                    else
                    {
                        itm.Is_PDF_Exists = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.Error("WebApp Controller - Get_Product_Volts" + ex.ToString());
            }

            //return PartialView("_Product_Volts",pdViewModel.Volt);

            return Json(RenderPartialViewToString("_Product_Volts", pdViewModel.Volt));
        }

        public string RenderPartialViewToString(string viewName, object model)
        {
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        public ActionResult Get_Product_Detail_By_Name(string language, string Col1)
        {

            ProductDetailViewModel pViewModel = new ProductDetailViewModel();

            ProductDetailsManager _pMan = new ProductDetailsManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            pViewModel.Volts.Add(_pMan.Get_Product_Detail_By_Name(Col1));

            foreach (var item in pViewModel.Volts)
            {
                item.Product_Details_Header = _pMan.Get_Product_Details_Header(item.Product_Column_Ref_Id);

                foreach (var itm in item.Product_Details)
                {
                    string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), itm.Col1 + ".pdf");

                    if (System.IO.File.Exists(path))
                    {
                        itm.Is_PDF_Exists = true;
                    }
                    else
                    {
                        itm.Is_PDF_Exists = false;
                    }
                }

            }

            

            return View("Product", pViewModel);
        }

        public ActionResult Get_Product_Detail_By_Competitor_Name(string language, string competitor)
        {

            ProductDetailViewModel pViewModel = new ProductDetailViewModel();

            ProductDetailsManager _pMan = new ProductDetailsManager();

            int language_Id = 0;

            if (Language.en.ToString() == language)
            {
                language_Id = (int)Language.en;
            }
            else
            {
                language_Id = (int)Language.ch;
            }

            pViewModel.Volts.Add(_pMan.Get_Product_Detail_By_Competitor_Name(competitor));

            foreach (var item in pViewModel.Volts)
            {
                item.Product_Details_Header = _pMan.Get_Product_Details_Header(item.Product_Column_Ref_Id);

                foreach (var itm in item.Product_Details)
                {
                    string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), itm.Col1 + ".pdf");

                    if (System.IO.File.Exists(path))
                    {
                        itm.Is_PDF_Exists = true;
                    }
                    else
                    {
                        itm.Is_PDF_Exists = false;
                    }
                }

            }

            return View("Product", pViewModel);
        }
    }
}
