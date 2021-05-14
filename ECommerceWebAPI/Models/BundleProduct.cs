using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Models
{
    public class BundleProduct
    {
        [Key]
        public int ID { get; set; }
        public int BundleID { get; set; }
        public int ProductID { get; set; }

        public virtual Bundle bundles { get; set; }
        public virtual Product products { get; set; }
    }
}