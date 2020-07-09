using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [DisplayName("Chức vụ")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string RoleName { get; set; }
        
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = "Không được để trống!")]
        public string RoleDes { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}