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
    [Authorize(Roles = "Admin")]
    public class StatusRoomController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        
        public ActionResult Index()
        {
            return View(db.StatusRooms.ToList());
        }

        // GET: Admin/StatusRoom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusRoom statusRoom = db.StatusRooms.Find(id);
            if (statusRoom == null)
            {
                return HttpNotFound();
            }
            return View(statusRoom);
        }

        // GET: Admin/StatusRoom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/StatusRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,StatusName,StatusColor")] StatusRoom statusRoom)
        {
            if (ModelState.IsValid)
            {
                db.StatusRooms.Add(statusRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusRoom);
        }

        // GET: Admin/StatusRoom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusRoom statusRoom = db.StatusRooms.Find(id);
            if (statusRoom == null)
            {
                return HttpNotFound();
            }
            return View(statusRoom);
        }

        // POST: Admin/StatusRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,StatusName,StatusColor")] StatusRoom statusRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusRoom);
        }

        // GET: Admin/StatusRoom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusRoom statusRoom = db.StatusRooms.Find(id);
            if (statusRoom == null)
            {
                return HttpNotFound();
            }
            return View(statusRoom);
        }

        // POST: Admin/StatusRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusRoom statusRoom = db.StatusRooms.Find(id);
            db.StatusRooms.Remove(statusRoom);
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
