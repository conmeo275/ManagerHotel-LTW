using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.Areas.Admin.Models;

namespace QuanLyKhachSan.DAL
{
    public class QLKSDbContext: DbContext
    {
        public QLKSDbContext() : base("name = QuanLyTestOneDbConnectionString")
        {

        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<StatusRoom> StatusRooms { get; set; }

        public DbSet<Revervation> Revervations { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceProduct> ServiceProduct { get; set; }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public System.Data.Entity.DbSet<QuanLyKhachSan.Areas.Admin.Models.Role> Roles { get; set; }
    }
}