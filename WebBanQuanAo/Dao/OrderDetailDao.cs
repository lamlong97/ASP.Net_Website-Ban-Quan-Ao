using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Dao
{
    public class OrderDetailDao
    {
        ShopQuanAoOnlineEntities db = null;
        public OrderDetailDao()
        {
            db = new ShopQuanAoOnlineEntities();
        }
        public bool Insert(OrderDetail detail)
        {
            try {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}