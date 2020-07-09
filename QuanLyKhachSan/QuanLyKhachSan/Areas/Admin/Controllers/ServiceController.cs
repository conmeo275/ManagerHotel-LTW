using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Areas.Admin.Models;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Lễ tân")]
    public class ServiceController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        
        public ActionResult Index()
        {
            var service = db.Service.Include(s => s.Revervation).Include(s => s.ServiceProduct);
            return View(service.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }
        
        public ActionResult Create(int? id)
        {
            ViewBag.ReverID = new SelectList(db.Revervations.Where(x => x.ReverID == id), "ReverID", "GuestName");
            ViewBag.ProductID = new SelectList(db.ServiceProduct, "ProductID", "ProductName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,ReverID,ProductID,Quantity")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Service.Add(service);
                db.SaveChanges();

                //UpdatePayment
                var payment = db.Payments.SingleOrDefault(x => x.ReverID == service.ReverID);
                var product = db.ServiceProduct.SingleOrDefault(x => x.ProductID == service.ProductID);
                payment.ServiceFee = payment.ServiceFee + product.ProductPrice * service.Quantity;
                payment.Amount = payment.Amount + payment.ServiceFee;
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Details","Revervation", new { id = service.ReverID});
            }

            ViewBag.ReverID = new SelectList(db.Revervations, "ReverID", "GuestName", service.ReverID);
            ViewBag.ProductID = new SelectList(db.ServiceProduct, "ProductID", "ProductName", service.ProductID);
            return View(service);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReverID = new SelectList(db.Revervations, "ReverID", "GuestName", service.ReverID);
            ViewBag.ProductID = new SelectList(db.ServiceProduct, "ProductID", "ProductName", service.ProductID);
            return View(service);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,ReverID,ProductID,Quantity")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReverID = new SelectList(db.Revervations, "ReverID", "GuestName", service.ReverID);
            ViewBag.ProductID = new SelectList(db.ServiceProduct, "ProductID", "ProductName", service.ProductID);
            return View(service);
        }

        // GET: Admin/Service/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Service.Find(id);
            db.Service.Remove(service);
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
