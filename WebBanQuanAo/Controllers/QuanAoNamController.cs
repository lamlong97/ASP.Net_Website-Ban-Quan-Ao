using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class QuanAoNamController : Controller
    {
        ShopQuanAoOnlineEntities _db = new ShopQuanAoOnlineEntities();
        // GET: QuanAoNam
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuanAoNam()
        {
            ViewBag.meta = "san-pham";
            //List<Product> cList = _db.Products.Where(x => x.categoryid == 2 && x.id == 3).ToList();
            //return View(cList);
            var v = (from t in _db.Products
                     where t.categoryid == 2
                     select t).Take(4);
            return View(v.ToList());
        }

        public ActionResult QuanAoNam1()
        {
            ViewBag.meta = "san-pham";
            //List<Product> cList = _db.Products.Where(x => x.categoryid == 2).ToList();
            //return View(cList);
                var v = from t in _db.Products
                        where t.categoryid == 2
                        select t;
                return View(v.ToList());
        }
    }
}