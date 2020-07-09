using QuanLyKhachSan.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.Models
{
    [FluentValidation.Attributes.Validator(typeof(UserValidator))]
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        //[Required(ErrorMessage = "Họ & Tên không được để trống!")]
        [DisplayName("Họ & Tên")]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Email không tồn tại!")]
        public string Email { get; set; }

        [DisplayName("Số điện thoại")]
        //[Required(ErrorMessage = "Số điện thoại không được để trống!")]
        [MaxLength(17, ErrorMessage = "Tối đa 17 kí tự")]
        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập số")]
        public string Phone { get; set; }

        [DisplayName("Số chứng minh thư")]
        //[Required(ErrorMessage = "Không được để trống!")]
        [MaxLength(17, ErrorMessage = "Tối đa 17 kí tự")]
        [MinLength(5, ErrorMessage = "Tối thiểu 5 kí tự")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Chỉ được nhập số")]
        public string CMND { get; set; }
        
        public virtual ICollection<OrderModel> OrderModels { get; set; }

        //[Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [DisplayName("Tên đăng nhập")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UserName { get; set; }

        //[Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Password { get; set; }
    }
}