using ClothesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWeb.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Partial_itemsByCateId(int cateid)
        {
            var items = db.Products.Where(x => x.ProductCategoryId == cateid).ToList();
            return PartialView(items);
        }
    }
}