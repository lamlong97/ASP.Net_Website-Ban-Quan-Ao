using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class QuanAoNuController : Controller
    {
        ShopQuanAoOnlineEntities _db = new ShopQuanAoOnlineEntities();
        // GET: QuanAoNu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuanAoNu()
        {
            ViewBag.meta = "san-pham";
            //List<Product> cList = _db.Products.Where(x => x.categoryid == 1).ToList();
            //return View(cList);
            var v = (from t in _db.Products
                     where t.categoryid == 1
                     select t).Take(4);
            return View(v.ToList());
        }

        public ActionResult QuanAoNu1()
        {
            ViewBag.meta = "san-pham";
            List<Product> cList = _db.Products.Where(x => x.categoryid == 1).ToList();
            return View(cList);
        }
    }
}