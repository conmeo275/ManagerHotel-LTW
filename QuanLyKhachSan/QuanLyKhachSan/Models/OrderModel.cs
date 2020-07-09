using QuanLyKhachSan.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }

        [DisplayName("Ngày tạo phiếu")]
        public DateTime? OrderDateTime { get; set; }

        [DisplayName("Loại phòng")]
        public string OrderRoom { get; set; }

        [ForeignKey("UserAccount")]
        public int? UserID { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [DisplayName("Check In")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [OrderValidator]
        public DateTime? CheckIn { get; set; }

        [Required(ErrorMessage = "Không được để trống!")]
        [DisplayName("Check Out")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [OrderValidator]
        public DateTime? CheckOut { get; set; }

        public bool Status { get; set; }
    }
}