using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Areas.Admin.Models;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    public class RevervationController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var revervations = db.Revervations.OrderByDescending(x => x.InDateTime).Include(r => r.Room).Include(r => r.UserAccount);
            return View(revervations.ToList());
        }

        [Authorize(Roles = "Admin, Lễ tân")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revervation revervation = db.Revervations.Find(id);
            if (revervation == null)
            {
                return HttpNotFound();
            }
            var pay = db.Payments.SingleOrDefault(x => x.ReverID == revervation.ReverID);
            ViewBag.PaymentID = pay.PayID;
            ViewBag.ReverId = revervation.ReverID;
            Multi sr = new Multi();
            return View(sr);
        }

        [Authorize(Roles = "Admin, Lễ tân")]
        public ActionResult Choice()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Lễ tân")]
        public ActionResult Create(int choice)
        {
            if (choice == 2206)
            {
                ViewBag.Choice = 1;
            }
            else
            {
                ViewBag.Choice = 2;
            }
            ViewBag.RoomId = new SelectList(db.Rooms.Where(x => x.StatusRoom.StatusName == "Trống"), "RoomId", "RoomName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReverID,InDateTime,OutDateTime,UserID,RoomId,Paying,GuestName,GuestEmail,GuestPhone,GuestCMND")] Revervation revervation)
        {
            if (ModelState.IsValid)
            {
                UserAccount usr = db.UserAccounts.SingleOrDefault(x => x.Phone == revervation.GuestPhone);
                if (usr != null)
                {
                    revervation.UserID = usr.UserID;
                    revervation.GuestName = usr.FullName;
                    revervation.GuestPhone = usr.Phone;
                    revervation.GuestEmail = usr.Email;
                    revervation.GuestCMND = usr.CMND;
                }
                revervation.InDateTime = DateTime.Now;
                revervation.Paying = false;
                db.Revervations.Add(revervation);
                db.SaveChanges();

                //CreatePayment
                var room = db.Rooms.SingleOrDefault(x => x.RoomId == revervation.RoomId);
                Payment payment = new Payment();
                payment.ReverID = revervation.ReverID;
                payment.RoomFee = room.RoomType.Price;
                payment.ServiceFee = 0;
                payment.Amount = payment.RoomFee;
                db.Payments.Add(payment);
                db.SaveChanges();

                return RedirectToAction("MultipleModel", "HomeAdmin");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomName", revervation.RoomId);
            return View(revervation);
        }

        [Authorize(Roles = "Admin, Lễ tân")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revervation revervation = db.Revervations.Where(x => x.ReverID == id).Include(r => r.Room).FirstOrDefault();
            if (revervation == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms.Where(x => x.StatusID == 1 || x.RoomId == revervation.RoomId), "RoomId", "RoomName", revervation.RoomId);
            return View(revervation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReverID,GuestName,GuestEmail,GuestPhone,GuestCMND,UserID,InDateTime,OutDateTime,RoomId,Paying")] Revervation revervation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revervation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MultipleModel", "HomeAdmin");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomId", revervation.RoomId);
            return View(revervation);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Revervation revervation = db.Revervations.Find(id);
            if (revervation == null)
            {
                return HttpNotFound();
            }
            return View(revervation);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Revervation revervation = db.Revervations.Find(id);
            db.Revervations.Remove(revervation);
            db.SaveChanges();
            return RedirectToAction("MultipleModel", "HomeAdmin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Admin, Lễ tân")]
        public ActionResult Clean(int id)
        {
            Room room = db.Rooms.Find(id);
            room.StatusID = 1;
            db.Entry(room).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MultipleModel", "HomeAdmin");
        }
    }
}
