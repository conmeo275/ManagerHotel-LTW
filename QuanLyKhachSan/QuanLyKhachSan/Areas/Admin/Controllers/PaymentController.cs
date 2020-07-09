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
    public class PaymentController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReverID = new SelectList(db.Revervations.Where(x => x.ReverID == payment.ReverID), "ReverID", "GuestName", payment.ReverID);
            return View(payment);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PayID,ReverID,RoomFee,ServiceFee,Amount")] Payment payment, string ipNV)
        {
            if (ModelState.IsValid)
            {
                //UpdateRevervation
                var rever = db.Revervations.Find(payment.ReverID);
                rever.Paying = true;
                rever.OutDateTime = DateTime.Now;
                db.Entry(rever).State = EntityState.Modified;
                db.SaveChanges();
                //UpdatePayment
                TimeSpan? time = rever.OutDateTime - rever.InDateTime;
                double a = time.Value.TotalHours;
                double b = Math.Ceiling(a);
                if (b <= 1)
                {
                    payment.RoomFee = payment.RoomFee;
                }
                else if(b <= 2)
                {
                    payment.RoomFee = payment.RoomFee + payment.RoomFee/2;
                }
                else
                {
                    int c = Convert.ToInt32(Math.Ceiling(b / 24));          
                    payment.RoomFee = payment.RoomFee * 3 * c;
                }
                payment.Amount = payment.RoomFee + payment.ServiceFee;
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                //CreateBill
                Bill bill = new Bill();
                bill.Emp = ipNV;
                var pay = db.Payments.SingleOrDefault(x => x.ReverID == payment.ReverID);
                bill.PayID = pay.PayID;
                bill.CurrentTime = DateTime.Now;
                db.Bills.Add(bill);
                db.SaveChanges();

                var billID = db.Bills.SingleOrDefault(x => x.PayID == pay.PayID);
                return RedirectToAction("Details","Bill", new { id = billID.BillID});
            }
            ViewBag.ReverID = new SelectList(db.Revervations.Where(x => x.ReverID == payment.ReverID), "ReverID", "GuestName", payment.ReverID);
            return View(payment);
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
