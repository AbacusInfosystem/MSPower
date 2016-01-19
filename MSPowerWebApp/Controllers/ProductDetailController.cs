using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using System.IO;
using MSPowerInfo;
using MSPowerWebApp.Common;
using MSPowerWebApp.Models;
using MSPowerManager;
using ExceptionManagement.Logger;

namespace MSPowerWebApp.Controllers
{
    public class ProductDetailController : Controller
    {
        //
        // GET: /ProductDetail/


        public ActionResult Index(ProductDetailViewModel pdViewModel)
        {
            ViewBag.Title = "MS POWER ERP :: Create, Update";

            // if tempdata is having a value, it means that user has landed in edit mode.

            if (TempData["Product_Detail_View_Model"] != null)
            {
                pdViewModel = (ProductDetailViewModel)TempData["Product_Detail_View_Model"];
            }

            // if productdetailid is 0 it means that the user has landed in create mode.

            // hence flush the pdViewModel object by creating a new instance.

            if (pdViewModel.Product_Detail.Product_Detail_Id == 0)
            {
                pdViewModel.Product_Detail = new ProductDetailInfo();
            }
            else
            {
                string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), pdViewModel.Product_Detail.Product_Detail_Id + ".pdf");

                if (System.IO.File.Exists(path))
                {
                    pdViewModel.Is_PDF_Exists = true;
                }
                else
                {
                    pdViewModel.Is_PDF_Exists = false;
                }
            }
            

            ProductDetailManager pdMan = new ProductDetailManager();

            pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(pdViewModel.Filter.Product_Column_Ref_Id);

            //pdViewModel.Product_Detail = pdMan.Get_Product_Detail_By_Id(pdViewModel.Filter.Product_Detail_Id);

            //pdViewModel.Product_Detail = pdMan.Get_Product_Detail_By_Id(product_detail_Id);


            

            return View("Index", pdViewModel);

        }

        // THIS IS THE FIRST ACTION METHOD WHICH GETS HIT WHEN PRODUCT LISTING PAGE IS CALLED.

        public ActionResult Search(ProductDetailViewModel pdViewModel)
        {
            ViewBag.Title = "MS POWER :: Search";

            if (TempData["pdViewModel"] != null)
            {
                pdViewModel = (ProductDetailViewModel)TempData["pdViewModel"];
            }

            return View("Search", pdViewModel);
        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCT CATEGORIES FROM DB.

        public JsonResult Get_Product_Categories(ProductDetailViewModel pdViewModel)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            //PaginationInfo pager = pdViewModel.Pager;

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

                //pager = pdViewModel.Pager;

                pdViewModel.Product_Categories = pdMan.Get_Product_Categories(language_Id);

                //pdViewModel.Pager = pager;

                //pdViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pdViewModel.Pager.TotalRecords, pdViewModel.Pager.CurrentPage + 1, pdViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            

            return Json(pdViewModel, JsonRequestBehavior.AllowGet);

        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCT CATEGORIES FROM DB.

        public JsonResult Get_Product_Volts(int productCategoryId)
        {
            ProductDetailManager pdMan = new ProductDetailManager();

            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            try
            {
                pdViewModel.Volts = pdMan.Get_Product_Volts(productCategoryId);
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }

            return Json(pdViewModel, JsonRequestBehavior.AllowGet);

        }

        // WHEN PRODUCT LISTING PAGE GETS LOADED, THIS METHOD GETS HIT TO GET ALL PRODUCT CATEGORIES FROM DB.

        //public JsonResult Get_Product_Details(int? productCategoryColumnMappingId, int productColumnRefId)
        //{

        public JsonResult Get_Product_Details(ProductDetailViewModel pdViewModel)
        {


            ProductDetailManager pdMan = new ProductDetailManager();

            //ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            PaginationInfo pager = pdViewModel.Pager;

            try

            {
                pager = pdViewModel.Pager;

                pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(pdViewModel.Filter.Product_Column_Ref_Id);

                pdViewModel.Product_Details = pdMan.Get_Product_Details(ref pager, pdViewModel.Filter.Product_Category_Column_Mapping_Id, pdViewModel.Filter.Product_Column_Ref_Id);

                pdViewModel.Pager = pager;

                pdViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", pdViewModel.Pager.TotalRecords, pdViewModel.Pager.CurrentPage + 1, pdViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Get_Tests" + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return Json(pdViewModel);

        }

        // WHEN USER CLICKS ON EDIT BUTTON FROM PRODUCT LISTING PAGE, THIS METHOD WOULD GET HIT.

        public ActionResult Get_Product_Detail_By_Id(ProductDetailViewModel pdViewModel)
        {
            try
            {
               
                ProductDetailManager pdMan = new ProductDetailManager();

                pdViewModel.Product_Details_Header = pdMan.Get_Product_Details_Header(pdViewModel.Filter.Product_Column_Ref_Id);

                pdViewModel.Product_Detail = pdMan.Get_Product_Detail_By_Id(pdViewModel.Filter.Product_Detail_Id, pdViewModel.Filter.Product_Column_Ref_Id);

                string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), pdViewModel.Product_Detail.Product_Detail_Id + ".pdf");

                if (System.IO.File.Exists(path))
                {
                    pdViewModel.Is_PDF_Exists = true;
                }
                else
                {
                    pdViewModel.Is_PDF_Exists = false;
                }
            }

            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller-Get_Test_By_Id" + ex.ToString());
            }

            return View("Index", pdViewModel);
        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS CREATING A NEW RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Insert(ProductDetailViewModel pdViewModel)
        {

            try
            {
                ProductDetailManager pdMan = new ProductDetailManager();

                pdViewModel.Product_Detail.Product_Category_Column_Mapping_Id = pdViewModel.Filter.Product_Category_Column_Mapping_Id;

                pdViewModel.Product_Detail.Product_Detail_Id = pdMan.Insert_Product_Detail(pdViewModel.Product_Detail);

                pdViewModel.Filter.Product_Detail_Id = pdViewModel.Product_Detail.Product_Detail_Id;

                PdfUpload(pdViewModel.Upload_File, pdViewModel.Product_Detail.Product_Detail_Id.ToString());

                pdViewModel.Friendly_Message.Add(MessageStore.Get("PD001"));
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Insert" + ex.ToString());
            }

            //TempData["pdViewModel"] = pdViewModel;

            //return RedirectToAction("Search");

            TempData["Product_Detail_View_Model"] = pdViewModel;

            return RedirectToAction("Index", pdViewModel);

        }

        // IF USER CLICKS ON SAVE BUTTON, AND IF USER IS UPDATING AN EXISTING RECORD, THEN THIS METHOD WOULD GET HIT.

        public ActionResult Update(ProductDetailViewModel pdViewModel)
        {

            try
            {
                ProductDetailManager pdMan = new ProductDetailManager();

                pdViewModel.Product_Detail.Product_Category_Column_Mapping_Id = pdViewModel.Filter.Product_Category_Column_Mapping_Id;

                pdViewModel.Product_Detail.Product_Detail_Id = pdViewModel.Filter.Product_Detail_Id;

                pdMan.Update_Product_Detail(pdViewModel.Product_Detail);

                //name = pdViewModel.Product_Detail.Product_Detail_Id.ToString() + "_" + pdViewModel.Product_Detail.

                PdfUpload(pdViewModel.Upload_File, pdViewModel.Product_Detail.Product_Detail_Id.ToString());

                pdViewModel.Friendly_Message.Add(MessageStore.Get("PD002"));
            }
            catch (Exception ex)
            {
                pdViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - Update" + ex.ToString());
            }

            TempData["Product_Detail_View_Model"] = pdViewModel;

            return RedirectToAction("Index", pdViewModel);

        }


        public void PdfUpload(HttpPostedFileBase file, string id)
        {
            ProductDetailViewModel pdViewModel = new ProductDetailViewModel();

            if (file != null && file.ContentLength > 0)
                try
                {
                    if ((Path.GetExtension(file.FileName) == ".pdf"))
                    {
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), id + ".pdf");

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

        public FileResult Download_Product_Details_PDF(int product_Details_Id)
        {
            string path = "";

            try
            {
                path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["PdfUploadProductDetailsPath"]).ToString(), product_Details_Id + ".pdf");
            }
            catch(Exception ex)
            {
                Logger.Error("Product Details Controller - Download_Product_Details_PDF" + ex.ToString());
            }

            return File(path, "application/pdf", "Product Details.pdf");
        }
    }
}
