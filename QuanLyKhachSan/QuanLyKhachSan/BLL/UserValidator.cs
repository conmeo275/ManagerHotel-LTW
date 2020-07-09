using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyKhachSan.Models;
using QuanLyKhachSan.DAL;

namespace QuanLyKhachSan.BLL
{
    public class UserValidator: AbstractValidator<UserAccount>
    {
        public UserValidator()
        {
            RuleFor(x => x.FullName).NotNull().WithMessage("Họ & Tên không được để trống!");
            RuleFor(x => x.Password).NotNull().WithMessage("Mật khẩu không được để trống!");
            RuleFor(x => x.CMND).NotNull().Must(BeUniqueCMND).WithMessage("Chứng minh thư này đã được đăng ký");
            RuleFor(x => x.Phone).NotNull().Must(BeUniquePhone).WithMessage("Số điện thoại này đã được đăng ký");
            RuleFor(x => x.UserName).NotNull().Must(BeUniqueUserName).WithMessage("Tên đăng nhập đã tồn tại");
        }

        private bool BeUniqueCMND(string cmnd)
        {
            return new QLKSDbContext().UserAccounts.FirstOrDefault(x => x.CMND == cmnd) == null;
        }

        private bool BeUniquePhone(string phone)
        {
            return new QLKSDbContext().UserAccounts.FirstOrDefault(x => x.Phone == phone) == null;
        }

        private bool BeUniqueUserName(string name)
        {
            return new QLKSDbContext().UserAccounts.FirstOrDefault(x => x.UserName == name) == null;
        }
    }
}