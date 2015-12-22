using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MSPowerWebApp.Common;
namespace MSPowerWebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Menu

            routes.MapRoute(
                name: "menu-1",
                url: "cms/product/search",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-2",
                url: "cms/product/search",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-3",
                url: "cms/services/search",
                defaults: new { controller = "Services", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-4",
                url: "cms/news-letter/search",
                defaults: new { controller = "NewsLetter", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-5",
                url: "cms/about-us",
                defaults: new { controller = "AboutUs", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-6",
                url: "cms/contact-us/search",
                defaults: new { controller = "ContactUs", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "menu-7",
               url: "cms/gallery/search",
               defaults: new { controller = "Gallery", action = "Search", id = UrlParameter.Optional }
            );

            #endregion

            #region CMS

            #region Product

            routes.MapRoute(
               name: "product-1",
               url: "cms/product",
               defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "product-2",
               url: "cms/product/search",
               defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "product-3",
               url: "cms/product/insert-product",
               defaults: new { controller = "Product", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "product-4",
               url: "cms/product/update-product",
               defaults: new { controller = "Product", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "product-5",
               url: "cms/product/get-products",
               defaults: new { controller = "Product", action = "Get_Products", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "product-6",
              url: "cms/product/get-product-by-id",
              defaults: new { controller = "Product", action = "Get_Product_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "product-7",
             url: "cms/product/delete-product",
             defaults: new { controller = "Product", action = "Delete", id = UrlParameter.Optional }
         );
            #endregion



            #region Services

           
            routes.MapRoute(
               name: "services-2",
               url: "cms/services/search",
               defaults: new { controller = "Services", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "services-3",
               url: "cms/services/insert-services",
               defaults: new { controller = "Services", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "services-4",
               url: "cms/services/update-services",
               defaults: new { controller = "Services", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "services-5",
               url: "cms/services/get-services",
               defaults: new { controller = "Services", action = "Get_Services", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "services-6",
              url: "cms/services/get-services-by-id",
              defaults: new { controller = "Services", action = "Get_Services_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "services-7",
             url: "cms/services/delete-services",
             defaults: new { controller = "Services", action = "Delete", id = UrlParameter.Optional }
         );

            routes.MapRoute(
              name: "services-1",
              url: "cms/services",
              defaults: new { controller = "Services", action = "Index", id = UrlParameter.Optional }
          );

            #endregion




            #region NewsLetter

            routes.MapRoute(
               name: "newsletter-1",
               url: "cms/newsletter",
               defaults: new { controller = "NewsLetter", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "newsletter-2",
               url: "cms/newsletter/search",
               defaults: new { controller = "NewsLetter", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "newsletter-3",
               url: "cms/newsletter/insert-newsletter",
               defaults: new { controller = "NewsLetter", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "newsletter-4",
               url: "cms/newsletter/update-newsletter",
               defaults: new { controller = "NewsLetter", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "newsletter-5",
               url: "cms/newsletter/get-newsletters",
               defaults: new { controller = "NewsLetter", action = "Get_NewsLetters", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "newsletter-6",
              url: "cms/newsletter/get-newsletter-by-id",
              defaults: new { controller = "NewsLetter", action = "Get_NewsLetter_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "newsletter-7",
             url: "cms/newsletter/delete-newsletter",
             defaults: new { controller = "NewsLetter", action = "Delete", id = UrlParameter.Optional }
         );


            #endregion




            routes.MapRoute(
                name: "cms-1",
                url: "cms/login",
                defaults: new { controller = "Authenticate", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "cms-2",
                url: "cms/authenticate",
                defaults: new { controller = "Authenticate", action = "Authenticate", id = UrlParameter.Optional }
            );

            #endregion

            #region Website

            routes.MapRoute(
               name: "website-1",
               url: "{language}/product/",
               defaults: new { controller = "WebSite", action = "Product", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
           );

            routes.MapRoute(
              name: "website-2",
              url: "{language}/product-listing/",
              defaults: new { controller = "WebSite", action = "ProductListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-3",
              url: "{language}/services/",
              defaults: new { controller = "WebSite", action = "Service", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-4",
              url: "{language}/service-listing/",
              defaults: new { controller = "WebSite", action = "ServiceListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-5",
              url: "{language}/news-letter/",
              defaults: new { controller = "WebSite", action = "NewsLetter", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-6",
              url: "{language}/news-letter-listing/",
              defaults: new { controller = "WebSite", action = "NewsLetterListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
             name: "website-7",
             url: "{language}/contact-us/",
             defaults: new { controller = "WebSite", action = "ContactUs", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
         );

            routes.MapRoute(
              name: "website-8",
              url: "{language}/contact-us-listing/",
              defaults: new { controller = "WebSite", action = "ContactUsListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            #endregion

            routes.MapRoute(
                name: "default-01",
                url: "{controller}/{action}/{language}",
                defaults: new { controller = "WebSite", action = "Index", language = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "default-02",
               url: "{controller}/{action}",
               defaults: new { controller = "WebSite", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}