using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;
namespace WebBanQuanAo.Controllers
{

    public class TempController : Controller
    {
        ShopQuanAoOnlineEntities _db = new ShopQuanAoOnlineEntities();
        // GET: Temp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getMenu(Menu menu)
        {
            var v = from t in _db.Menus
                    where t.hide == true
                    orderby t.order ascending
                    select t;
           
            return PartialView(v.ToList());
        }
    }
}