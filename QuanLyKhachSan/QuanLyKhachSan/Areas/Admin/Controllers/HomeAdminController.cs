using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.DAL;
using System.Web.Routing;
using QuanLyKhachSan.Areas.Admin.Models;
using System.Data.Entity;

namespace QuanLyKhachSan.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Lễ tân")]
    public class HomeAdminController : Controller
    {
        private QLKSDbContext db = new QLKSDbContext();

        public ActionResult MultipleModel()
        {
            Multi rr = new Multi();
            return View(rr);
        }

        //public List<Room> GetRoom()
        //{
        //    List<Room> ro = db.Rooms.ToList();
        //    return ro;
        //}

        //public List<Revervation> GetRevervation()
        //{
        //    List<Revervation> re = db.Revervations.Where(x => x.Paying == false).ToList();
        //    return re;
        //}

        //public List<StatusRoom> GetStatusRoom()
        //{
        //    List<StatusRoom> sr = db.StatusRooms.ToList();
        //    return sr;
        //}
    }
}