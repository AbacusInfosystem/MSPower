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

    }
}
