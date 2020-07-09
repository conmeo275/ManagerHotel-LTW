using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class StatusRoom
    {
        [Key]
        public int StatusID { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusName { get; set; }
        
        public string StatusColor { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}