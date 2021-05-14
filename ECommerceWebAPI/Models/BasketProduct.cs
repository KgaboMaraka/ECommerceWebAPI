using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Models
{
    public class BasketProduct
    {
        [Key]
        public int ID { get; set; }
        public int BasketID { get; set; }
        public int CustomerID { get; set; }
        public int BundleID { get; set; }
        public int ProductID { get; set; }

        public virtual Basket basket { get; set; }
    }
}