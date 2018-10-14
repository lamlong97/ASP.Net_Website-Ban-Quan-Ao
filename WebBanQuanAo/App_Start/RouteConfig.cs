using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanQuanAo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "QuanAoNu1",
                url: "san-pham/quan-ao-nu",
                defaults: new { controller = "QuanAoNu", action = "QuanAoNu1", meta = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
             );

            routes.MapRoute(
                name: "QuanAoNam1",
                url: "san-pham/quan-ao-nam",
                defaults: new { controller = "QuanAoNam", action = "QuanAoNam1", meta = UrlParameter.Optional },
                namespaces: new[] { "WebBanQuanAo.Controllers" }
             );

            routes.MapRoute("Detail", "{type}/{meta}/{id}",
            new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
            new RouteValueDictionary
            {
                {"type","san-pham"}
            },
            namespaces: new[] { "WebBanQuanAo.Controllers" });
            routes.MapRoute("Home", "{type}",
              new { Controller = "Default", action = "Index"},
              new RouteValueDictionary
              {
                    {"type","trang-chu" }
              },
              namespaces: new[] { "WebBanQuanAo.Controllers" }
              );
            routes.MapRoute("Register", "{type}",
             new { Controller = "Register", action = "Index" },
             new RouteValueDictionary
             {
                    {"type","dang-nhap" }
             },
             namespaces: new[] { "WebBanQuanAo.Controllers" }
             );
            routes.MapRoute("Success", "{type}",
              new { Controller = "ThanhToan", action = "ThanhCong" },
              new RouteValueDictionary
              {
                    {"type","hoan-thanh" }
              },
              namespaces: new[] { "WebBanQuanAo.Controllers" }
              );
            routes.MapRoute("Payment", "{type}",
              new { Controller = "ThanhToan", action = "Index" },
              new RouteValueDictionary
              {
                    {"type","thanh-toan" }
              },
              namespaces: new[] { "WebBanQuanAo.Controllers" }
              );
            routes.MapRoute("Cart", "{type}",
              new { Controller = "GioHang", action = "GioHang" },
              new RouteValueDictionary
              {
                    {"type","gio-hang" }
              },
              namespaces: new[] { "WebBanQuanAo.Controllers" }
              );
            routes.MapRoute("News", "{type}",
            new { Controller = "News", action = "Index" },
            new RouteValueDictionary
            {
                    {"type","tin-tuc" }
            },
            namespaces: new[] { "WebBanQuanAo.Controllers" }
            );
            routes.MapRoute("Contact", "{type}",
           new { Controller = "Contact", action = "Index" },
           new RouteValueDictionary
           {
                    {"type","lien-he" }
           },
           namespaces: new[] { "WebBanQuanAo.Controllers" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "WebBanQuanAo.Controllers" }
           
            );
        }
    }
}
