using MSPowerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MSPowerWebApp.Controllers
{
    public class LanguageController : Controller
    {
        //
        // GET: /Language/

        public ActionResult Index(LanguageViewModel lViewModel)
        {
            lViewModel.Filter.Language = Convert.ToString(Session["Language"]);

            return View(lViewModel);
        }

        public ActionResult SetLanguage(LanguageViewModel lViewModel)
        {
            Session["Language"] = lViewModel.Filter.Language;

            return View("Index",lViewModel);
        }
    }
}
