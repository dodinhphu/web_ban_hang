using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhuDD4_MorckProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // home 
            routes.MapRoute(
                  name: "Home",
                  url: "home/{id}/{id2}",
                  defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
              );
            // product sắp xếp
            routes.MapRoute(
                  name: "product_sap_xep",
                  url: "product/{loaisapxep}/{id}",
                  defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
              );
            // tìm kiếm product
            routes.MapRoute(
                  name: "timkiem_product",
                  url: "product/{loaisapxep}/{id}",
                  defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
              );
            // Details Product 
            routes.MapRoute(
                  name: "Details_Product",
                  url: "details/product/{id}",
                  defaults: new { controller = "Home", action = "Details_Product", id = UrlParameter.Optional }
              );
            // list don hang
            routes.MapRoute(
                  name: "list don hang",
                  url: "listorder",
                  defaults: new { controller = "DonHang", action = "Index", id = UrlParameter.Optional }
              );
            // details don hang
            routes.MapRoute(
                  name: "details don hang",
                  url: "detailsorder/{id}",
                  defaults: new { controller = "DonHang", action = "DetailsOrder", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
