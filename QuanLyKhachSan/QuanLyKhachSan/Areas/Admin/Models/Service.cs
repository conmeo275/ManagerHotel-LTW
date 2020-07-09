using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        [ForeignKey("Revervation")]
        public int? ReverID { get; set; }
        public virtual Revervation Revervation { get; set; }

        [ForeignKey("ServiceProduct")]
        public int? ProductID { get; set; }
        public virtual ServiceProduct ServiceProduct { get; set; }

        [DisplayName("Số lượng")]
        [Required(ErrorMessage = "Không được để trống!")]
        [Range(1, 10, ErrorMessage = "Số lượng chỉ bán từ 1 - 10 đơn vị cho mỗi sản phẩm!")]
        public int Quantity { get; set; }
    }
}