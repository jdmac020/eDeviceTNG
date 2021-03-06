﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Antlr.Runtime;

namespace WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "LogOff",
                url: "Account/LogOff/",
                defaults: new {area = "", controller = "Account", action = "LogOff" }
                );
            //routes.MapRoute(
            //    "Area",
            //    "",
            //    new { area = "AreaZ", controller = "Default", action = "ActionY" }
            //);
        }
    }
}
