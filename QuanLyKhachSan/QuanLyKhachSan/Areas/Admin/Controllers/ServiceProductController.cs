using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Areas.Admin.Models;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceProductController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        
        public ActionResult Index()
        {
            return View(db.ServiceProduct.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductPrice,ProductImage")] ServiceProduct serviceProduct, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                if (ProductImage != null)
                {
                    var fileName = Path.GetFileName(ProductImage.FileName);
                    serviceProduct.ProductImage = fileName;
                    string path = Path.Combine(Server.MapPath("~/Assets/ProductImage"), fileName);
                    ProductImage.SaveAs(path);
                }
                db.ServiceProduct.Add(serviceProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serviceProduct);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProduct serviceProduct = db.ServiceProduct.Find(id);
            if (serviceProduct == null)
            {
                return HttpNotFound();
            }
            return View(serviceProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductPrice,ProductImage")] ServiceProduct serviceProduct, HttpPostedFileBase ProductImage)
        {
            if (ModelState.IsValid)
            {
                if (ProductImage != null)
                {
                    var fileName = Path.GetFileName(ProductImage.FileName);
                    serviceProduct.ProductImage = fileName;
                    string path = Path.Combine(Server.MapPath("~/Assets/ProductImage"), fileName);
                    ProductImage.SaveAs(path);
                }
                db.Entry(serviceProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serviceProduct);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceProduct serviceProduct = db.ServiceProduct.Find(id);
            if (serviceProduct == null)
            {
                return HttpNotFound();
            }
            return View(serviceProduct);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceProduct serviceProduct = db.ServiceProduct.Find(id);
            db.ServiceProduct.Remove(serviceProduct);
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
