using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [DisplayName("Tên phòng")]
        public int RoomName { get; set; }

        [ForeignKey("RoomType")]
        public int? TypeID { get; set; }
        public virtual RoomType RoomType { get; set; }

        [ForeignKey("StatusRoom")]
        public int? StatusID { get; set; }
        public virtual StatusRoom StatusRoom { get; set; }
    }
}