using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Dao;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        public ActionResult Index()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            return View(lstGioHang);
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(x => x.ThanhTien);
            }
            return dTongTien;
        }
        [HttpPost]
        public ActionResult ThanhToan(string nguoinhan,string dienthoai,string diachi,string email)
        {
            var order = new Order();
            order.NgayTao = DateTime.Now;
            order.TenKH = nguoinhan;
            order.DiaChi = diachi;
            order.DienThoai = dienthoai;
            order.Email = email;
            order.TrangThai = false;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<GioHang>)Session["GioHang"];
                var detailDao = new OrderDetailDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.IDProduct = item.iMaSP;
                    orderDetail.IDOrder = id;
                    orderDetail.Price = item.ThanhTien;
                    orderDetail.Quantity = item.iSoLuong;
                    detailDao.Insert(orderDetail);
                    Session["GioHang"] = null;
                }
            }
            catch(Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult ThanhCong()
        {
            return View();
        }
    }
}