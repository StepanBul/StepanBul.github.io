using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.Models
{
    public class Order//ввод персональных данных
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        public string surname { get; set; }
        [Display(Name = "Введите адрес")]
        public string adress { get; set; }
        [Display(Name = "Введите телефон")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }
        [Display(Name = "Введите почту")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn (false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
