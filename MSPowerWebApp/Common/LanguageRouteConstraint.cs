using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MSPowerWebApp.Common
{
    public class LanguageRouteConstraint: IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (routeDirection == RouteDirection.IncomingRequest)
            {
                string language = values["language"].ToString();

                if (language == "en" || language == "ch")

                    return true;

                else

                    return false;

            }
            
            return false;
        }
    }
}