using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;
namespace WebBanQuanAo.Controllers
{
    public class DefaultController : Controller
    {
        ShopQuanAoOnlineEntities _db = new ShopQuanAoOnlineEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getBanner()
        {
            var v = from t in _db.banners
                    select t;
            return PartialView(v.ToList());
        }
        public ActionResult Menu()
        {
            //var category = _db.Menus.Where(x => x.Id == 3).FirstOrDefault();
            //ViewBag.meta = "san-pham";
            List<Category> cList = _db.Categories.ToList();
            return PartialView("Menu", cList);
        }
        public ActionResult getProduct(long id)
        {
            //ViewBag.meta = metatitle;
            ViewBag.meta = "san-pham";
            List<Product> cList = _db.Products.Where(x => x.categoryid == id).ToList();
            return View(cList);
        }
        public ActionResult getNews()
        {
            var v = from t in _db.News
                    where t.hide == true
                    orderby t.order ascending
                    select t;
            return PartialView(v.ToList());
        }
    }
}