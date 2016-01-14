using ExceptionManagement.Logger;
using MSPowerWebApp.Common;
using MSPowerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSPowerWebApp.Controllers
{
    public class ImageUploadController : Controller
    {
        //
        // GET: /ImageUpload/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Upload(HttpPostedFileBase file)
        {
            ImageUploadViewModel iuViewModel = new ImageUploadViewModel();

            if (file != null && file.ContentLength > 0)
                try
                {
                    if ((Path.GetExtension(file.FileName) == ".jpeg") || (Path.GetExtension(file.FileName) == ".jpg") || (Path.GetExtension(file.FileName) == ".png"))
                    {
                        string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath"]).ToString(), Path.GetFileName(file.FileName));

                        file.SaveAs(path);

                        iuViewModel.Friendly_Message.Add(MessageStore.Get("IU001"));

                        ViewBag.Message = "File uploaded successfully";
                    }
                    else
                    {
                        iuViewModel.Friendly_Message.Add(MessageStore.Get("IU003"));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Debug(ex.StackTrace);
                }
            else
            {
                iuViewModel.Friendly_Message.Add(MessageStore.Get("IU002"));
            }  
            return View("Index",iuViewModel);
        }


        public JsonResult GetImages()
        {
            ImageUploadViewModel imgViewModel = new ImageUploadViewModel();

            // Process the list of files found in the directory.

            string[] fileEntries = Directory.GetFiles(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath"]).ToString());

            foreach (string fileName in fileEntries)
            {
                imgViewModel.File_Name.Add(Path.GetFileName(fileName));
            }

            return Json(imgViewModel, JsonRequestBehavior.AllowGet);
        }

        public void DeleteImage(string imageName)
        {
            ImageUploadViewModel imgViewModel = new ImageUploadViewModel();

            if (System.IO.File.Exists(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath"].ToString() + "//" + imageName)))
            {
                System.IO.File.Delete(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath"].ToString() + "//" + imageName));    
            }
        }
    }
}






























//public ActionResult uploadPartial(HttpPostedFileBase file)
//{
//    string path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImageUploadPath"]).ToString(), Path.GetFileName(file.FileName));

//    var images = Directory.GetFiles(path).Select(x => new ImageUploadViewModel
//    {
//       // Url = Url.Content("/ImageUpload/GetImages" + Path.GetFileName(x))
//    });

//    return View(images);
//}