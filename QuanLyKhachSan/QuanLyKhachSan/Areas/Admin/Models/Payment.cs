using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Payment
    {
        [Key]
        public int PayID { get; set; }

        [ForeignKey("Revervation")]
        public int? ReverID { get; set; }
        public virtual Revervation Revervation { get; set; }

        [DisplayName("Tiền phòng")]
        public int RoomFee { get; set; }

        [DisplayName("Tiền dịch vụ")]
        public int ServiceFee { get; set; }

        [DisplayName("Tổng tiền")]
        public int Amount { get; set; }
    }
}