using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Dao
{
    public class OrderDao
    {
        ShopQuanAoOnlineEntities db = null;
        public OrderDao()
        {
            db = new ShopQuanAoOnlineEntities();
        }
        public int Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
    }
}