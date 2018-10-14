using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class OrderDetailsController : Controller
    {
        private ShopQuanAoOnlineEntities db = new ShopQuanAoOnlineEntities();

        // GET: Admin/OrderDetails
        public ActionResult Index(int? id)
        {
            
            var orderDetails = db.OrderDetails.Include(o => o.Order).Include(o => o.Product).Where(o=>o.IDOrder==id);
            var tongtien = db.OrderDetails.Where(a => a.IDOrder == id).Sum(a => a.Price);
            ViewBag.TongTien = tongtien;
            return View(orderDetails.ToList());
        }

        // GET: Admin/OrderDetails/Details/5
      /* public float TongTien(int? id)
        {
            var product = db.Products;
            var order = db.Orders;
            var orderDetail = db.OrderDetails;
            var tongtien = from a in order
                           join b in orderDetail on a.ID equals b.IDOrder
                           join c in product on b.IDProduct equals c.id
                           where a.ID == id
                           select sum
        }*/
    }
}
