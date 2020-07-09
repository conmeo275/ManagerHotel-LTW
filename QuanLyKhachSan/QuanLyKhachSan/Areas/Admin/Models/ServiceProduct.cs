using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class ServiceProduct
    {
        [Key]
        public int ProductID { get; set; }

        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string ProductName { get; set; }

        [DisplayName("Giá sản phẩm")]
        [Range(1000, int.MaxValue, ErrorMessage = "Chỉ nhập số dương và ít nhất là 1000 VNĐ!")]
        [Required(ErrorMessage = "Không được để trống!")]
        public int ProductPrice { get; set; }

        [DisplayName("Hình")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string ProductImage { get; set; }
    }
}