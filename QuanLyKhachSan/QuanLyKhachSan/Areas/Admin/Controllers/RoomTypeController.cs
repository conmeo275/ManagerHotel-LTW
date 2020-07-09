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
    public class RoomTypeController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();
        
        public ActionResult Index()
        {
            return View(db.RoomTypes.ToList());
        }
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomType = db.RoomTypes.Find(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TypeID,TypeName,TypeImage,Description,Price")] RoomType roomType, HttpPostedFileBase TypeImage)
        {
            if (ModelState.IsValid)
            {
                if (TypeImage != null)
                {
                    var fileName = Path.GetFileName(TypeImage.FileName);
                    roomType.TypeImage = fileName;
                    string path = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                    TypeImage.SaveAs(path);
                }
                db.RoomTypes.Add(roomType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomType);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomType = db.RoomTypes.Find(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TypeID,TypeName,TypeImage,Description,Price")] RoomType roomType, HttpPostedFileBase TypeImage)
        {
            if (ModelState.IsValid)
            {
                if (TypeImage != null)
                {
                    var fileName = Path.GetFileName(TypeImage.FileName);
                    roomType.TypeImage = fileName;
                    string path = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                    TypeImage.SaveAs(path);
                }
                db.Entry(roomType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomType);
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomType = db.RoomTypes.Find(id);
            if (roomType == null)
            {
                return HttpNotFound();
            }
            return View(roomType);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomType roomType = db.RoomTypes.Find(id);
            db.RoomTypes.Remove(roomType);
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
