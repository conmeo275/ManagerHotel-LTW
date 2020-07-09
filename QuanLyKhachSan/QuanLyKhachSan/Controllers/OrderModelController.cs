using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Areas.Admin.Models;
using QuanLyKhachSan.BLL;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    [Authorize]
    public class OrderModelController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        public ActionResult Room()
        {
            return View(db.RoomTypes.ToList());
        }

        public ActionResult Create(int id)
        {
            RoomType type = db.RoomTypes.Find(id);
            ViewBag.TypeName = type.TypeName;
            ViewBag.Price = type.Price;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderDateTime,OrderRoom,UserID,CheckIn,CheckOut,Status")] OrderModel orderModel, int id, int userid)
        {
            if (ModelState.IsValid)
            {
                orderModel.UserID = userid;
                orderModel.OrderDateTime = DateTime.Now;
                RoomType type = db.RoomTypes.Find(id);
                orderModel.OrderRoom = type.TypeName;
                db.OrderModels.Add(orderModel);
                db.SaveChanges();
                ModelState.Clear();
                TempData["Message"] = "Done !!!";
                return RedirectToAction("Room");
            }
            
            ViewBag.UserID = new SelectList(db.UserAccounts, "UserID", "FullName", orderModel.UserID);
            return View(orderModel);
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
