using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyKhachSan.BLL
{
    public class OrderValidatorAttribute : RangeAttribute
    {
        public OrderValidatorAttribute() : base(typeof(DateTime), DateTime.Now.ToString(), DateTime.MaxValue.ToString())
        { }
    }
}