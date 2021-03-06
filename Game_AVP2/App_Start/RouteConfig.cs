﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Game_AVP2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "AdminWeapons",                                           // Route name
                "Admin/AdminItems/AdminWeapons/{action}",                            // URL with parameters
                new { controller = "AdminWeapons", action = "{action}" }  // Parameter defaults
            );
            routes.MapRoute(
                "AdminArmours",                                           // Route name
                "Admin/AdminItems/AdminArmours/{action}",                            // URL with parameters
                new { controller = "AdminArmours", action = "{action}" }  // Parameter defaults
            );
            routes.MapRoute(
                "AdminCharacters #2",                                           // Route name
                "Admin/AdminCharacters/AdminStaticCharacters/{action}",                            // URL with parameters
                new { controller = "AdminStaticCharacters", action = "{action}" }  // Parameter defaults
            );
            routes.MapRoute(
                "AdminMonsters",                                           // Route name
                "Admin/AdminCharacters/AdminMonsters/{action}",                            // URL with parameters
                new { controller = "AdminMonsters", action = "{action}" }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Game", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
