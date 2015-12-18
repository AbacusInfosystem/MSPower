using MSPowerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace MSPowerWebApp.Filters
{
    public class LanguageAttribute : ActionFilterAttribute
   
    {
        
        public LanguageAttribute()
        
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        
        {
            
            RouteValueDictionary a = actionContext.RouteData.Values;

            // IF USER HAS SELECTED A LANGUAGE

            if (a.ContainsKey("language"))
            
            {
                SetLanguage((string)actionContext.ActionParameters["language"]);
            }

            else // ELSE SET DEFAULT LANGUAGE AS ENGLISH
            
            {
                if (HttpContext.Current.Session["Language"] == null)
               
                {
                    HttpContext.Current.Session["Language"] = Language.en.ToString();    
                }
           
            }
           
            base.OnActionExecuting(actionContext);

        }

        private void SetLanguage(string language)
       
        {
            
            // IF SELECTED LANGUAGE IS ENGLISH

            if (language.ToLower() == Language.en.ToString())
           
            {
                HttpContext.Current.Session["Language"] = language.ToLower();
            }

            // ELSE IF SELECTED LANGUAGE IS CHINESE

            else if (language.ToLower() == Language.ch.ToString())
           
            {
                HttpContext.Current.Session["Language"] = language.ToLower();
            }

            // IF NEITHER EN NOT CH IS SELETED, THEN SET ENGLISH AS DEFAULT LANGUAGE

            else
           
            {
                HttpContext.Current.Session["Language"] = Language.en.ToString();
            }
       
        }
    }
}