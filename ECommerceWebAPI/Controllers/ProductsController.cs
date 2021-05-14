using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ECommerceWebAPI.Data;
using ECommerceWebAPI.Models;

namespace ECommerceWebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private ECommerceWebAPIContext db = new ECommerceWebAPIContext();

        // GET: api/Products
        public IQueryable<Product> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            IQueryable<Product> product = db.Products.Where(p => p.CategoryID == id);
            //Product product = db.Products.Find(id);
            if (product == null)
            {
                return null;
            }

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}