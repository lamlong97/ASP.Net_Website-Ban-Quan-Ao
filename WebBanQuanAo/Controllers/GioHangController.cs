using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        ShopQuanAoOnlineEntities db = new ShopQuanAoOnlineEntities();
        // GET: GioHang
        public ActionResult Index()
        {
            return View();
        }
        // lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                // nếu giỏ hàng chưa tồn tại thì tiến hành tạo
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        // Thêm Giỏ Hàng
        public ActionResult ThemGioHang(int iMaSP, string strURL)
        {
            Product product = db.Products.SingleOrDefault(n => n.id == iMaSP);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //lấy session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            // kiểm tra sản phẩm đã tồn tại trong session chưa 
            GioHang sanpham = lstGioHang.Find(n => n.iMaSP == iMaSP);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaSP);
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }

        }

        public ActionResult CapNhatGioHang(int iMaSP, FormCollection f)
        {
            Product product = db.Products.SingleOrDefault(x => x.id == iMaSP);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(x => x.iMaSP == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return View("GioHang");
        }
        public ActionResult XoaGioHang(int iMaSP)
        {
            Product product = db.Products.SingleOrDefault(x => x.id == iMaSP);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(x => x.iMaSP == iMaSP);
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(x => x.iMaSP == sanpham.iMaSP);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "GioHang");
            }
            return RedirectToAction("GioHang");
        }
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "GioHang");
            }
            ViewBag.TongTien = TongTien();
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(x => x.iSoLuong);
            }
            return iTongSoLuong;
        }

        private string TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(x => x.ThanhTien);
            }
            return $"{dTongTien:0,0}"; 
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }


    }
}