using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Help;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class DefaultController : Controller
    {
        private ShopQuanAoOnlineEntities db = new ShopQuanAoOnlineEntities();
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string user_name, string password)
        {
            string passwordMD5 = Common.EncryptMD5(password);
            var user = db.Logins.SingleOrDefault(x => x.user_name == user_name && x.password == passwordMD5);
            if (user != null)
            {
                Session["id"] = user.id;
                Session["user_name"] = user.user_name;
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập thất bại hoặc bạn không có quyền vào ";
            return View();
        }
        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["user_name"] = null;
            return RedirectToAction("Login");
        }
    }
}