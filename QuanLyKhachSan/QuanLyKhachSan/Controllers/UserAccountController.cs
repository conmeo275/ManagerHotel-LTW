using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PasswordSecurity;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    
    public class UserAccountController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }
        
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "UserID,FullName,Email,Phone,CMND,UserName,Password")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.Password = PasswordStorage.CreateHash(userAccount.Password);
                db.UserAccounts.Add(userAccount);
                db.SaveChanges();
                ModelState.Clear();
                TempData["Message"] = "Tài khoản của bạn đã được kích hoạt !";
                return View();
            }

            return View(userAccount);
        }

        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccounts.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,FullName,Email,Phone,CMND,UserName,Password")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details","UserAccount", new { id = userAccount.UserID});
            }
            return View(userAccount);
        }

        [Authorize]
        public ActionResult History(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.UserAccounts.Find(id);
            return View(db.OrderModels.Where(x => x.UserID == user.UserID).OrderByDescending(x => x.OrderDateTime).ToList());
        }

        [Authorize]
        public ActionResult DeleteHistory(int? id)
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
            return View(order);
        }

        [HttpPost, ActionName("DeleteHistory")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHistory(int id)
        {
            OrderModel order = db.OrderModels.Find(id);
            var usr = db.UserAccounts.Where(x => x.UserID == order.UserID).First();
            db.OrderModels.Remove(order);
            db.SaveChanges();
            return RedirectToAction("History", "UserAccount", new { id = usr.UserID });
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
