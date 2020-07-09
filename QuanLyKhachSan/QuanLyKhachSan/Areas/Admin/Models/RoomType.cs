using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class RoomType
    {
        [Key]
        public int TypeID { get; set; }

        [DisplayName("Loại phòng")]
        public string TypeName { get; set; }

        [DisplayName("Hình ảnh")]
        public string TypeImage { get; set; }

        [DisplayName("Mô tả")]
        public string Description { get; set; }

        [DisplayName("Giá phòng")]
        public int Price { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}