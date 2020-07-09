using QuanLyKhachSan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Areas.Admin.Models
{
    public class Revervation
    {
        [Key]
        public int ReverID { get; set; }

        [Required(ErrorMessage = "Họ & Tên không được để trống!")]
        [DisplayName("Họ & Tên")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string GuestName { get; set; }

        [EmailAddress(ErrorMessage = "Email không tồn tại!")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string GuestEmail { get; set; }

        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [MaxLength(17, ErrorMessage = "Tối đa 17 kí tự")]
        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập số")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string GuestPhone { get; set; }

        [DisplayName("Số chứng minh thư")]
        [Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(17, ErrorMessage = "Tối đa 17 kí tự")]
        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập số")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string GuestCMND { get; set; }

        [ForeignKey("UserAccount")]
        public int? UserID { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        [DisplayName("Check In")]
        public DateTime? InDateTime { get; set; }

        [DisplayName("Check Out")]
        public DateTime? OutDateTime { get; set; }

        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public virtual Room Room { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public bool Paying { get; set; }
    }
}