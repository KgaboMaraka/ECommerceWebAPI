using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECommerceWebAPI.Data
{
    public class ECommerceWebAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ECommerceWebAPIContext() : base("name=ECommerceWebAPIContext")
        {
        }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.Bundle> Bundles { get; set; }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.BundleProduct> BundleProducts { get; set; }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.Basket> Baskets { get; set; }

        public System.Data.Entity.DbSet<ECommerceWebAPI.Models.BasketProduct> BasketProducts { get; set; }
    }
}
