using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; }
        public float RoomPrice { get; set; }
        public string RoomPic { get; set; }
    }
}