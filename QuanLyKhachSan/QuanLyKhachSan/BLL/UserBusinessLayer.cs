using QuanLyKhachSan.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.BLL
{
    public class UserBusinessLayer
    {
        public bool IsValidUser(UserDetails user)
        {
            if (user.UserName == "Admin" && user.Password == "5")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}