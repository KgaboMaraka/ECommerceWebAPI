using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Models
{
    public class Bundle
    {
        public Bundle()
        {
            this.bundleProducts = new HashSet<BundleProduct>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }

        //public virtual Product products { get; set; }

        public virtual ICollection<BundleProduct> bundleProducts { get; set; }
    }
}