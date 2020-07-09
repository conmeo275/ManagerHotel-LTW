using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyKhachSan.Areas.Admin.Models;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Multi
    {
        private QLKSDbContext db = new QLKSDbContext();
         
        public List<Room> LRooms()
        {
            List<Room> ro = db.Rooms.ToList();
            return ro;
        }
        
        public List<Revervation> LRevervations()
        {
            List<Revervation> re = db.Revervations.Where(x => x.Paying == false).ToList();
            return re;
        }
        
        public List<StatusRoom> LStatusRooms()
        {
            List<StatusRoom> st = db.StatusRooms.ToList();
            return st;
        }
        
        public List<Service> LServices()
        {
            List<Service> se = db.Service.ToList();
            return se;
        }
    }
}