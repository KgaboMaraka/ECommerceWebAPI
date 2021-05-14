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
    public class BasketsController : ApiController
    {
        private ECommerceWebAPIContext db = new ECommerceWebAPIContext();


        // GET: api/Baskets/5
        [ResponseType(typeof(Basket))]
        public int GetBasket(int id)
        {
            int value = 0;
            List<BasketProduct> basketProduct = db.BasketProducts.Where(b => b.BasketID == id).ToList();
            foreach(BasketProduct item in basketProduct)
            {
                var amount = db.Products.Where(p => p.ID == item.ProductID).FirstOrDefault().Amount;
                value = value + Convert.ToInt32(amount);
            }

            return value;
        }

        // PUT: api/Baskets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBasket(int id, Basket basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != basket.ID)
            {
                return BadRequest();
            }

            db.Entry(basket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Baskets
        [ResponseType(typeof(Basket))]
        public IHttpActionResult PostBasket(BasketProduct basketProduct)
        {
            Basket basket = new Basket();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!ProductInBundle(basketProduct.ProductID, basketProduct.BundleID))
            {
                basketProduct = new BasketProduct();
                BasketProduct error = new BasketProduct();
                return CreatedAtRoute("DefaultApi", new { id = basketProduct.ID }, basketProduct);                 
            }

            if(BasketProductsCompleted(basketProduct.BasketID, basketProduct.BundleID))
            {
                basketProduct = new BasketProduct();
                BasketProduct error = new BasketProduct();
                return CreatedAtRoute("DefaultApi", new { id = basketProduct.ID }, basketProduct);
            }


            if (basketProduct.BasketID == 0)
            {
                basket.Date = DateTime.Now;
                basket.Complete = false;

                db.Baskets.Add(basket);
                db.SaveChanges();
                basketProduct.BasketID = basket.ID;
            }
            else
            {
                basket = db.Baskets.Where(b => b.ID == basketProduct.BasketID).FirstOrDefault();
            }            

            db.BasketProducts.Add(basketProduct);            
            db.SaveChanges();

            List<BasketProduct> lstbasketProduct = db.BasketProducts.Where(b => b.BundleID == basketProduct.BundleID).ToList();
            List<BundleProduct> lstbundleProduct = db.BundleProducts.Where(b => b.BundleID == basketProduct.BundleID).ToList();

            basket.Complete = GetBasketStatus(lstbasketProduct, lstbundleProduct);
            PutBasket(basket.ID, basket);

            basketProduct.basket = basket;
            return CreatedAtRoute("DefaultApi", new { id = basketProduct.ID }, basketProduct);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BasketExists(int id)
        {
            return db.Baskets.Count(e => e.ID == id) > 0;
        }

        protected Boolean GetBasketStatus(List<BasketProduct> lstbasketProduct, List<BundleProduct> lstbundleProduct)
        {
            Boolean basketComplete = true;
            foreach (BundleProduct item in lstbundleProduct)
            {
                if (lstbasketProduct.FindIndex(t => t.ProductID == item.ProductID) < 0)
                {
                    basketComplete = false;
                    break;
                }
            }
            return basketComplete;
        }

        protected Boolean ProductInBundle(int productID, int bundleID)
        {
            List<BundleProduct> lstbundleProduct = db.BundleProducts.Where(b => b.BundleID == bundleID).ToList();
            
            foreach (BundleProduct item in lstbundleProduct)
            {
                if (item.ProductID == productID)
                {
                    return true;
                }
            }
            return false;
        }

        protected Boolean BasketProductsCompleted(int basketID, int bundleID)
        {
            List<BasketProduct> lstbasketProduct = db.BasketProducts.Where(b => b.BasketID == basketID && b.BundleID == bundleID).ToList();
            List<BundleProduct> lstbundleProduct = db.BundleProducts.Where(b => b.BundleID == bundleID).ToList();

            Boolean basketComplete = true;
            foreach (BundleProduct item in lstbundleProduct)
            {
                if (lstbasketProduct.FindIndex(t => t.ProductID == item.ProductID) < 0)
                {
                    basketComplete = false;
                    break;
                }
            }
            return basketComplete;
        }
    }
}