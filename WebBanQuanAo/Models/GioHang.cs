using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Models
{
    public class GioHang
    {
        ShopQuanAoOnlineEntities db = new ShopQuanAoOnlineEntities();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        // Hàm tạo giỏ hàng
        public GioHang(int MaSPGioHang)
        {
            iMaSP = MaSPGioHang;
            Product product = db.Products.Single(x => x.id == iMaSP);
            sTenSP = product.name;
            sHinhAnh = product.img;
            dDonGia = double.Parse(product.price.ToString());
            iSoLuong = 1;
        }
    }
}