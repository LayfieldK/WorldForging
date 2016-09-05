using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WorldForging
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "customer",
                url: "customer/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Customer"
                });

            routes.MapRoute(
                name: "product",
                url: "product/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Product"
                });

            routes.MapRoute(
                name: "order",
                url: "order/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Order"
                });

            routes.MapRoute(
                name: "worlds",
                url: "worlds/{*catch-all}",
                defaults: new
                {
                    controller = "Home",
                    action = "Worlds"
                });

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Worlds",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
