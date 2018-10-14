using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBanQuanAo.Help;
using WebBanQuanAo.Models;

namespace WebBanQuanAo.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ShopQuanAoOnlineEntities db = new ShopQuanAoOnlineEntities();

        // GET: Admin/Products
        public ActionResult Index(long? id=null)
        {
            getCategory(id);
            return View();
        }
        public void getCategory(long? selectedId=null)
        {
            ViewBag.Category = new SelectList(db.Categories.Where(x => x.hide == true)
                .OrderBy(x => x.order), "id", "name", selectedId);
        }
        public ActionResult getProduct(long? id)
        {
            if(id==null)
            {
                var v = db.Products.OrderBy(x => x.order).ToList();
                return PartialView(v);
            }
            var m = db.Products.Where(x => x.categoryid == id).OrderBy(x => x.order).ToList();
            return PartialView(m);
        }
        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            getCategory();
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,name,price,img,description,meta,size,color,hide,order,datebegin,categoryid")] Product product,HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                if (ModelState.IsValid)
                {
                    if (img != null)
                    {
                        //filename = Guid.NewGuid().ToString() + img.FileName;
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss-") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/upload/img/product"), filename);
                        img.SaveAs(path);
                        product.img = filename; //Lưu ý
                    }
                    else
                    {
                        product.img = "logo.png";
                    }
                    product.datebegin = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    product.meta = Functions.ConvertToUnSign(product.meta); //convert Tiếng Việt không dấu
                    product.order = getMaxOrder(product.categoryid);
                    db.Products.Add(product);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    return RedirectToAction("Index", "Products", new { id = product.categoryid });
                }
            }
            catch (DbEntityValidationException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(product);
        }


        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            getCategory(product.categoryid);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,name,price,img,description,meta,size,color,hide,order,datebegin,categoryid")] Product product, HttpPostedFileBase img)
        {
            try
            {
                var path = "";
                var filename = "";
                Product temp = db.Products.Find(product.id);
                if(ModelState.IsValid)
                {
                    if (img != null)
                    {
                        filename = DateTime.Now.ToString("dd-MM-yy-hh-mm-ss") + img.FileName;
                        path = Path.Combine(Server.MapPath("~/Content/images"), filename);
                        img.SaveAs(path);
                        temp.img = filename;
                    }
                    temp.name = product.name;
                    temp.price = product.price;
                    temp.description = product.description;
                    temp.meta = product.meta;
                    temp.color = product.color;
                    temp.size = product.size;
                    temp.hide = product.hide;
                    temp.order = product.order;
                    db.Entry(temp).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Products", new { id = product.categoryid });
                }
            }
            catch(DbEntityValidationException e)
            {
                throw e;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(product);
         
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
        public int getMaxOrder(long? CategoryId)
        {
            if (CategoryId == null)
                return 1;
            return db.Products.Where(x => x.categoryid == CategoryId).Count();
        }
    }
}
