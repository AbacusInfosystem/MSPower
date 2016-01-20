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
               url: "cms/productdetail/search",
               defaults: new { controller = "ProductDetail", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "menu-4",
                url: "cms/services/search",
                defaults: new { controller = "Services", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-5",
                url: "cms/news-letter/search",
                defaults: new { controller = "NewsLetter", action = "Search", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "menu-6",
                url: "cms/about-us",
                defaults: new { controller = "AboutUs", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "menu-7",
                url: "cms/contact-us/search",
                defaults: new { controller = "ContactUs", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "menu-8",
               url: "cms/event/search",
               defaults: new { controller = "Event", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
              name: "menu-9",
              url: "cms/job_opening/search",
              defaults: new { controller = "Job_Opening", action = "Search", id = UrlParameter.Optional }
           );


            routes.MapRoute(
             name: "menu-10",
             url: "cms/enquiry/search",
             defaults: new { controller = "Enquiry", action = "Search", id = UrlParameter.Optional }
          );


            routes.MapRoute(
            name: "menu-11",
            url: "cms/job_application/search",
            defaults: new { controller = "Job_Application", action = "Search", id = UrlParameter.Optional }
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

            #region ProductDetail

            routes.MapRoute(
               name: "productdetail-1",
               url: "cms/product-detail",
               defaults: new { controller = "ProductDetail", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "productdetail-2",
               url: "cms/product-detail/search",
               defaults: new { controller = "ProductDetail", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "productdetail-3",
               url: "cms/product-detail/insert",
               defaults: new { controller = "ProductDetail", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "productdetail-4",
               url: "cms/product-detail/update",
               defaults: new { controller = "ProductDetail", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "productdetail-5",
               url: "cms/product-detail/get-product-details",
               defaults: new { controller = "ProductDetail", action = "Get_ProductDetails", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "productdetail-6",
              url: "cms/product-detail/get-product-detail-by-id",
              defaults: new { controller = "ProductDetail", action = "Get_Product_Detail_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "productdetail-7",
             url: "cms/product-detail/delete-product-detail",
             defaults: new { controller = "ProductDetail", action = "Delete", id = UrlParameter.Optional }
         );

            routes.MapRoute(
             name: "productdetail-8",
             url: "cms/product-detail/download-pdf/{product_Details_Id}",
             defaults: new { controller = "ProductDetail", action = "Download_Product_Details_PDF", product_Details_Id = UrlParameter.Optional }
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

            routes.MapRoute(
            name: "newsletter-8",
            url: "cms/newsletter/download-pdf/{newsLetter_Id}",
            defaults: new { controller = "NewsLetter", action = "Download_Product_Details_PDF", newsLetter_Id = UrlParameter.Optional }
        );

            #endregion

            #region ContactUs

            routes.MapRoute(
               name: "contactus-1",
               url: "cms/contactus",
               defaults: new { controller = "ContactUs", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "contactus-2",
               url: "cms/contactus/search",
               defaults: new { controller = "ContactUs", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "contactus-3",
               url: "cms/contactus/insert-contactus",
               defaults: new { controller = "ContactUs", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "contactus-4",
               url: "cms/contactus/update-contactus",
               defaults: new { controller = "ContactUs", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "contactus-5",
               url: "cms/contactus/get-contactus",
               defaults: new { controller = "ContactUs", action = "Get_ContactUss", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "contactus-6",
              url: "cms/contactus/get-contactus-by-id",
              defaults: new { controller = "ContactUs", action = "Get_ContactUs_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "contactus-7",
             url: "cms/contactus/delete-contactus",
             defaults: new { controller = "ContactUs", action = "Delete", id = UrlParameter.Optional }
         );

            #endregion

            #region Event

            routes.MapRoute(
               name: "event-1",
               url: "cms/event",
               defaults: new { controller = "Event", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "event-2",
               url: "cms/event/search",
               defaults: new { controller = "Event", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "event-3",
               url: "cms/event/insert-event",
               defaults: new { controller = "Event", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "event-4",
               url: "cms/event/update-event",
               defaults: new { controller = "Event", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "event-5",
               url: "cms/event/get-events",
               defaults: new { controller = "Event", action = "Get_Events", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "event-6",
              url: "cms/event/get-event-by-id",
              defaults: new { controller = "Event", action = "Get_Event_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "event-7",
             url: "cms/event/delete-event",
             defaults: new { controller = "Event", action = "Delete", id = UrlParameter.Optional }
         );


            #endregion

            #region Job_Opening

            routes.MapRoute(
               name: "job_opening-1",
               url: "cms/job_opening",
               defaults: new { controller = "Job_Opening", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "job_opening-2",
               url: "cms/job_opening/search",
               defaults: new { controller = "Job_Opening", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "job_opening-3",
               url: "cms/job_opening/insert-job_opening",
               defaults: new { controller = "Job_Opening", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "job_opening-4",
               url: "cms/job_opening/update-job_opening",
               defaults: new { controller = "Job_Opening", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "job_opening-5",
               url: "cms/job_opening/get-job_opening",
               defaults: new { controller = "Job_Opening", action = "Get_Job_Openings", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "job_opening-6",
              url: "cms/job_opening/get-job_opening-by-id",
              defaults: new { controller = "Job_Opening", action = "Get_Job_Opening_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "job_opening-7",
             url: "cms/job_opening/delete-job_opening",
             defaults: new { controller = "Job_Opening", action = "Delete", id = UrlParameter.Optional }
         );
            #endregion

            #region Enquiry


            routes.MapRoute(
             name: "Enquiry-2",
             url: "cms/enquiry/search",
             defaults: new { controller = "Enquiry", action = "Search", id = UrlParameter.Optional }
         );


            routes.MapRoute(
              name: "Enquiry-1",
              url: "cms/enquiry/insert-enquiry",
              defaults: new { controller = "Enquiry", action = "Insert", id = UrlParameter.Optional }
          );


            routes.MapRoute(
              name: "Enquiry-3",
              url: "cms/enquiry/get-enquirys",
              defaults: new { controller = "Enquiry", action = "Get_Enquirys", id = UrlParameter.Optional }
          );


            routes.MapRoute(
             name: "Enquiry-4",
             url: "cms/enquiry/get-enquiry-by-id",
             defaults: new { controller = "Enquiry", action = "Get_Enquiry_By_Id", id = UrlParameter.Optional }
         );


            #endregion

            #region AboutUs

            routes.MapRoute(
               name: "aboutus-1",
               url: "cms/aboutus",
               defaults: new { controller = "AboutUs", action = "Index", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "aboutus-2",
               url: "cms/aboutus/search",
               defaults: new { controller = "AboutUs", action = "Search", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "aboutus-3",
               url: "cms/aboutus/insert-aboutus",
               defaults: new { controller = "AboutUs", action = "Insert", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "aboutus-4",
               url: "cms/aboutus/update-aboutus",
               defaults: new { controller = "AboutUs", action = "Update", id = UrlParameter.Optional }
           );

            routes.MapRoute(
               name: "aboutus-5",
               url: "cms/aboutus/get-aboutuss",
               defaults: new { controller = "AboutUs", action = "Get_AboutUss", id = UrlParameter.Optional }
           );

            routes.MapRoute(
              name: "aboutus-6",
              url: "cms/aboutus/get-aboutus-by-id",
              defaults: new { controller = "AboutUs", action = "Get_AboutUs_By_Id", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "aboutus-7",
             url: "cms/aboutus/delete-aboutus",
             defaults: new { controller = "AboutUs", action = "Delete", id = UrlParameter.Optional }
         );
            #endregion

            #region Job_Application


            routes.MapRoute(
             name: "Job_Application-2",
             url: "cms/job_application/search",
             defaults: new { controller = "Job_Application", action = "Search", id = UrlParameter.Optional }
         );


          //  routes.MapRoute(
          //    name: "Job_Application-1",
          //    url: "cms/job_application/insert-job_application",
          //    defaults: new { controller = "Job_Application", action = "Insert", id = UrlParameter.Optional }
          //);


            routes.MapRoute(
              name: "Job_Application-3",
              url: "cms/job_application/get-job_applications",
              defaults: new { controller = "Job_Application", action = "Get_Job_Applications", id = UrlParameter.Optional }
          );


            routes.MapRoute(
             name: "Job_Application-4",
             url: "cms/job_application/get-job_application-by-id",
             defaults: new { controller = "Job_Application", action = "Get_Job_Application_By_Id", id = UrlParameter.Optional }
         );


            #endregion

            #region Language

            routes.MapRoute(
               name: "language-1",
               url: "cms/language",
               defaults: new { controller = "Language", action = "Index", id = UrlParameter.Optional }
           );

            #endregion

            #region Upload
            routes.MapRoute(
               name: "upload-1",
               url: "upload/{module}/{id}",
               defaults: new { controller = "Upload", action = "Index", module = UrlParameter.Optional, id = UrlParameter.Optional }
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
               url: "{language}/product/{product_Column_Ref_Id}/{product_Category_Column_Mapping_Id}",
               defaults: new { controller = "WebSite", action = "Product", language = UrlParameter.Optional, product_Column_Ref_Id = UrlParameter.Optional, product_Category_Column_Mapping_Id = UrlParameter.Optional }
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
              url: "{language}/productdetail/",
              defaults: new { controller = "WebSite", action = "ProductDetail", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-4",
              url: "{language}/productdetail-listing/",
              defaults: new { controller = "WebSite", action = "ProductDetailListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-5",
              url: "{language}/services/",
              defaults: new { controller = "WebSite", action = "Service", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-6",
              url: "{language}/service-listing/",
              defaults: new { controller = "WebSite", action = "ServiceListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-7",
              url: "{language}/news-letter/{NewsLetter_Id}",
              defaults: new { controller = "WebSite", action = "Get_NewsLetter_By_Id", language = UrlParameter.Optional, NewsLetter_Id  = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-8",
              url: "{language}/news-letter-listing/",
              defaults: new { controller = "WebSite", action = "NewsLetterListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
             name: "website-9",
             url: "{language}/contact-us/",
             defaults: new { controller = "WebSite", action = "ContactUs", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
         );

            routes.MapRoute(
              name: "website-10",
              url: "{language}/contact-us-listing/",
              defaults: new { controller = "WebSite", action = "ContactUsListing", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );


             routes.MapRoute(
             name: "website-11",
             url: "{language}/job_opening/{Job_Opening_Id}",
             defaults: new { controller = "WebSite", action = "Get_Job_Opening_By_Id", language = UrlParameter.Optional, Job_Opening_Id = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }

           );

             routes.MapRoute(
              name: "website-12",
              url: "{language}/job_opening-listing/",
              defaults: new { controller = "WebSite", action = "Job_OpeningListing", language = UrlParameter.Optional }
              
             );

              routes.MapRoute(
             name: "website-13",
             url: "{language}/enquiry/",
             defaults: new { controller = "WebSite", action = "Enquiry", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }

           );

            routes.MapRoute(
             name: "website-14",
             url: "{language}/enquiry-listing/",
             defaults: new { controller = "WebSite", action = "EnquiryListing", language = UrlParameter.Optional }

                //constraints: new { language = new LanguageRouteConstraint() }
         );

              routes.MapRoute(
             name: "website-15",
             url: "{language}/job_application/",
             defaults: new { controller = "WebSite", action = "Job_Application", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }

           );

            routes.MapRoute(
             name: "website-16",
             url: "{language}/job_application-listing/",
             defaults: new { controller = "WebSite", action = "Job_ApplicationListing", language = UrlParameter.Optional }

             //constraints: new { language = new LanguageRouteConstraint() }
         );

            routes.MapRoute(
             name: "website-17",
             url: "{language}/aboutus/",
             defaults: new { controller = "WebSite", action = "AboutUs", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }

           );

            routes.MapRoute(
             name: "website-18",
             url: "insert-job-application",
             defaults: new { controller = "WebSite", action = "Insert_Job_Application", id = UrlParameter.Optional }
         );
           

            routes.MapRoute(
             name: "website-19",
             url: "{language}/event/",
             defaults: new { controller = "WebSite", action = "Event", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
         );

            routes.MapRoute(
              name: "website-20",
              url: "{language}/event-listing/",
              defaults: new { controller = "WebSite", action = "Event", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-21",
              url: "{language}/get-product-search/",
              defaults: new { controller = "WebSite", action = "Get_Product_Search", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-22",
              url: "web-app/get-event-images/{event_Id}",
              defaults: new { controller = "WebSite", action = "Get_Events_Images", event_Id = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );

            routes.MapRoute(
              name: "website-23",
              url: "{language}/set-language",
              defaults: new { controller = "WebSite", action = "SetLanguage", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
          );


            routes.MapRoute(
           name: "website-24",
           url: "insert-enquiry",
           defaults: new { controller = "WebSite", action = "Insert_Enquiry", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
         );

            routes.MapRoute(
          name: "website-25",
          url: "web-app/get-about-us",
          defaults: new { controller = "WebSite", action = "Get_AboutUs", id = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
        );

            routes.MapRoute(
          name: "website-26",
          url: "web-app/get-news",
          defaults: new { controller = "WebSite", action = "Get_NewsLetters", id = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
        );

            routes.MapRoute(
          name: "website-27",
          url: "web-app/get-hot-jobs",
          defaults: new { controller = "WebSite", action = "Get_Hot_Jobs", id = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
        );

            routes.MapRoute(
          name: "website-28",
          url: "web-app/get-events",
          defaults: new { controller = "WebSite", action = "Get_Events", id = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }
         );

            routes.MapRoute(
          name: "website-29",
          url: "{language}/service",
          defaults: new { controller = "WebSite", action = "Service", language = UrlParameter.Optional }
                //constraints: new { language = new LanguageRouteConstraint() }

        );

            #endregion

            #region Attachment

            routes.MapRoute(
            name: "image-upload-0",
            url: "image-upload/upload",
            defaults: new { controller = "ImageUpload", action = "Upload", id = UrlParameter.Optional }
            );

            routes.MapRoute(
          name: "image-upload-1",
          url: "image-upload",
          defaults: new { controller = "ImageUpload", action = "Index", id = UrlParameter.Optional }
          );

            #endregion


            routes.MapRoute(
              name: "default-03",
              url: "{language}",
              defaults: new { controller = "WebSite", action = "Index", language = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "default-04",
             url: "{language}",
             defaults: new { controller = "WebSite", action = "Index", language = UrlParameter.Optional }
         );

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