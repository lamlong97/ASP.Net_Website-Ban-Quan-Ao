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
    public class Feedback2Controller : Controller
    {
        private ShopQuanAoOnlineEntities db = new ShopQuanAoOnlineEntities();

        // GET: Admin/Feedback2
        public ActionResult Index()
        {
            return View(db.Feedback2.ToList());
        }

        // GET: Admin/Feedback2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback2 feedback2 = db.Feedback2.Find(id);
            if (feedback2 == null)
            {
                return HttpNotFound();
            }
            return View(feedback2);
        }

        // GET: Admin/Feedback2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Feedback2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Phone,Email,Address,Content,CreatedDate,Status")] Feedback2 feedback2)
        {
            if (ModelState.IsValid)
            {
                db.Feedback2.Add(feedback2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedback2);
        }

        // GET: Admin/Feedback2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback2 feedback2 = db.Feedback2.Find(id);
            if (feedback2 == null)
            {
                return HttpNotFound();
            }
            return View(feedback2);
        }

        // POST: Admin/Feedback2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Phone,Email,Address,Content,CreatedDate,Status")] Feedback2 feedback2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedback2);
        }

        // GET: Admin/Feedback2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback2 feedback2 = db.Feedback2.Find(id);
            if (feedback2 == null)
            {
                return HttpNotFound();
            }
            return View(feedback2);
        }

        // POST: Admin/Feedback2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback2 feedback2 = db.Feedback2.Find(id);
            db.Feedback2.Remove(feedback2);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
