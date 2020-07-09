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
using PasswordSecurity;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    
    public class EmployeeController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Role);
            return View(employees.ToList());
        }

        [Authorize(Roles = "Lễ tân")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,EmpName,EmpImage,EmpDayOfBirth,EmpEmail,RoleID,EmpAddress,EmpPhone,EmpUserName,EmpPassword")] Employee employee, HttpPostedFileBase EmpImage)
        {
            if (ModelState.IsValid)
            {
                if (EmpImage != null)
                {
                    var fileName = Path.GetFileName(EmpImage.FileName);
                    employee.EmpImage = fileName;
                    string path = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                    EmpImage.SaveAs(path);
                }
                employee.EmpPassword = PasswordStorage.CreateHash(employee.EmpPassword);
                db.Employees.Add(employee);
                db.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("Index");
            }

            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", employee.RoleID);
            return View(employee);
        }

        [Authorize(Roles = "Lễ tân")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", employee.RoleID);
            return View(employee);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,EmpName,EmpImage,EmpDayOfBirth,EmpEmail,RoleID,EmpAddress,EmpPhone,EmpUserName,EmpPassword")] Employee employee, HttpPostedFileBase EmpImage)
        {
            if (ModelState.IsValid)
            {
                if (EmpImage != null)
                {
                    var fileName = Path.GetFileName(EmpImage.FileName);
                    employee.EmpImage = fileName;
                    string path = Path.Combine(Server.MapPath("~/Assets/images"), fileName);
                    EmpImage.SaveAs(path);
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleID = new SelectList(db.Roles, "RoleID", "RoleName", employee.RoleID);
            return View(employee);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
