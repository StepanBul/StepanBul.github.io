using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        //[StringLength(5)]
        //[Required(ErrorMessage = "Длина не менее 5 символов")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        //[StringLength(5)]
        //[Required(ErrorMessage = "Длина не менее 5 символов")]
        public string surname { get; set; }
        [Display(Name = "Введите адрес")]
        //[StringLength(15)]
       // [Required(ErrorMessage = "Длина не менее 15 символов")]
        public string adress { get; set; }
        [Display(Name = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        //[StringLength(11)]
        //[Required(ErrorMessage = "Длина не менее 11 символов")]
        public string phone { get; set; }
        [Display(Name = "Введите почту")]
        [DataType(DataType.EmailAddress)]
        //[StringLength(10)]
        //[Required(ErrorMessage = "Длина не менее 10 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn (false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
