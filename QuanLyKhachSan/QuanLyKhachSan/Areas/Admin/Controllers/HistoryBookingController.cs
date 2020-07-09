using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Lễ tân")]
    public class HistoryBookingController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();

        public ActionResult Index()
        {
            return View(db.OrderModels.OrderByDescending(n => n.OrderDateTime).ToList());
        }

        public ActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel order = db.OrderModels.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            order.Status = true;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
            return View("Index");
        }

        public ActionResult Find(string option, string search)
        {
            if (option == "name")
            {
                return View(db.OrderModels.Where(x => x.UserAccount.FullName == search || search == null).ToList());
            }
            else if (option == "phone")
            {
                return View(db.OrderModels.Where(x => x.UserAccount.Phone == search || search == null).ToList());
            }
            else
            {
                return View(db.OrderModels.ToList());
            }
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
