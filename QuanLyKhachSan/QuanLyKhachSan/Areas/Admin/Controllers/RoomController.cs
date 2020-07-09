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
    public class RoomController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        
        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.RoomType).Include(r => r.StatusRoom);
            return View(rooms.ToList());
        }

        // GET: Admin/Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Admin/Room/Create
        public ActionResult Create()
        {
            ViewBag.TypeID = new SelectList(db.RoomTypes, "TypeID", "TypeName");
            ViewBag.StatusID = new SelectList(db.StatusRooms, "StatusID", "StatusName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoomId,RoomName,TypeID,StatusID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TypeID = new SelectList(db.RoomTypes, "TypeID", "TypeName", room.TypeID);
            ViewBag.StatusID = new SelectList(db.StatusRooms, "StatusID", "StatusName", room.StatusID);
            return View(room);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypeID = new SelectList(db.RoomTypes, "TypeID", "TypeName", room.TypeID);
            ViewBag.StatusID = new SelectList(db.StatusRooms, "StatusID", "StatusName", room.StatusID);
            return View(room);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoomId,RoomName,TypeID,StatusID")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypeID = new SelectList(db.RoomTypes, "TypeID", "TypeName", room.TypeID);
            ViewBag.StatusID = new SelectList(db.StatusRooms, "StatusID", "StatusName", room.StatusID);
            return View(room);
        }

        // GET: Admin/Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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
