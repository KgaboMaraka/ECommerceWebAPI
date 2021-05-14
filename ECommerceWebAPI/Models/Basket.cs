using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Models
{
    public class Basket
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Boolean Complete { get; set; }
    }
}