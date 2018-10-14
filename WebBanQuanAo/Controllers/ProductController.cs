using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;
namespace WebBanQuanAo.Controllers
{
    public class ProductController : Controller
    {
        ShopQuanAoOnlineEntities _db = new ShopQuanAoOnlineEntities();
        // GET: Product
        public ActionResult Index(string meta)
        {
            var v = from t in _db.Categories
                    where t.meta == meta
                    select t;
            return View(v.FirstOrDefault());

        }
        public ActionResult Detail( long id)
        {
            var v = from t in _db.Products
                    where t.id == id
                    select t;
            return View(v.FirstOrDefault());
        }
    }
}