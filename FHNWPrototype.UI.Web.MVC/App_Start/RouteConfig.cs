﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FHNWPrototype.UI.Web.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

       //     routes.MapRoute(
       //    name: "DefaultJsonExtension",
       //    url: "UserAccounts/visualizationdata.json",
       //       defaults: new { controller = "UserAccounts", action = "visualizationdata", format = "json" }
       //);
         

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}