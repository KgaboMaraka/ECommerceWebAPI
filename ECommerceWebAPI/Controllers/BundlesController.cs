using ECommerceWebAPI.Data;
using ECommerceWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerceWebAPI.Controllers
{
    public class BundlesController : ApiController
    {
        private ECommerceWebAPIContext db = new ECommerceWebAPIContext();
        // GET: api/Bundles
        public List<Bundle> Get()
        {
            List<Bundle> bundles = db.Bundles.ToList();
            return bundles;
        }
    }
}
