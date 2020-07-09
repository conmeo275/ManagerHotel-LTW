using QuanLyKhachSan.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyKhachSan.BLL;
using QuanLyKhachSan.DAL;
using PasswordSecurity;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserDetails user)
        {
            var emp = db.Employees.Where(x => x.EmpUserName == user.UserName).SingleOrDefault();
            var guest = db.UserAccounts.Where(x => x.UserName == user.UserName).SingleOrDefault();
            UserBusinessLayer bal = new UserBusinessLayer();
            if (bal.IsValidUser(user))
            {
                Session["User"] = "Admin";
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Index", "Employee", new { area = "Admin" });
            }
            else if(emp != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                bool result = PasswordStorage.VerifyPassword(user.Password, emp.EmpPassword);
                if (result)
                {
                    Session["User"] = emp;
                    if(emp.Role.RoleName == "Lễ tân")
                    {
                        return RedirectToAction("Index", "HistoryBooking", new { area = "Admin" });
                    }
                    else
                        return RedirectToAction("Mission", "HomeAdmin", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    return View("Login");
                }
            }
            else if (guest != null)
            {
                bool kq = PasswordStorage.VerifyPassword(user.Password, guest.Password);
                if (kq)
                {
                    Session["User"] = guest;
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    return View("Login");
                }
            }
            else
            {
                ModelState.AddModelError("CredentialError", "Tên đăng nhập hoặc mật khẩu không đúng.");
                return View("Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
                Session["User"] = null;
            return RedirectToAction("Login");
        }
    }
}