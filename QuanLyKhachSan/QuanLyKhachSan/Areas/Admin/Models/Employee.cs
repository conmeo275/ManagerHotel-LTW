using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }

        [DisplayName("Tên nhân viên")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ảnh đại diện!")]
        [DisplayName("Ảnh đại diện")]
        public string EmpImage { get; set; }

        [DisplayName("Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EmpDayOfBirth { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Email không tồn tại!")]
        public string EmpEmail { get; set; }

        [ForeignKey("Role")]
        public int? RoleID { get; set; }
        public virtual Role Role { get; set; }

        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string EmpAddress { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string EmpPhone { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [DisplayName("Tên đăng nhập")]
        public string EmpUserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string EmpPassword { get; set; }
    }
}