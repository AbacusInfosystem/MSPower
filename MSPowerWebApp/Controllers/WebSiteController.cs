using MSPowerWebApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ProductListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult Product(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ServiceListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult Service(string language)
        {
            return View();
        }

        [Language]
        public ActionResult NewsLetterListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult NewsLetter(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ContactUsListing(string language)
        {
            return View();
        }

        [Language]
        public ActionResult ContactUs(string language)
        {
            return View();
        }

    }
}
