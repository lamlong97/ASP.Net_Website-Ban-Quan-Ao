using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanQuanAo.Models;
namespace WebBanQuanAo.Dao
{
    public class ContactDao
    {
        ShopQuanAoOnlineEntities db = null;
        public ContactDao()
        {
            db = new ShopQuanAoOnlineEntities();
        }
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }
        public int InsertFeedBack(Feedback2 fb)
        {
            db.Feedback2.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}