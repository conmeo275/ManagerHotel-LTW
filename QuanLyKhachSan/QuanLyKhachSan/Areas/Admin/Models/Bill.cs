using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Bill
    {
        [Key]
        public int BillID { get; set; }

        [ForeignKey("Payment")]
        public int? PayID { get; set; }
        public virtual Payment Payment { get; set; }

        [DisplayName("Nhân viên")]
        public string Emp { get; set; }

        [DisplayName("Ngày xuất hóa đơn")]
        public DateTime? CurrentTime { get; set; }
    }
}