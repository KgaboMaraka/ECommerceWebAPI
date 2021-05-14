using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Models
{
    public class Product
    {        
        [Key]
        public int ID { get; set; }
        public string Brand { get; set; }
        public int CategoryID { get; set; }
        public string Amount { get; set; }

    }
}