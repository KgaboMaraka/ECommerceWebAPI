using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Models
{
    public class Category
    {
        public Category()
        {
            this.products = new HashSet<Product>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> products { get; set; }
    }
}