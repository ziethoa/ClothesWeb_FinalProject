using ClothesWeb.Models;
using ClothesWeb.Models.EF;
using PagedList;
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
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            var pageSize = 12;//bản ghi
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Detail(string alias, int id)
        {
            var item = db.Products.Find(id);
            return View(item);
        }
        public ActionResult ProductCategory(string alias, int id, int? page)
        {
            var cate = db.ProductCategories.Find(id);

            IEnumerable<Product> items = db.Products.OrderByDescending(x => x.Id);
            var pageSize = 12;//bản ghi
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            
            

            
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryId == id).ToPagedList(pageIndex, pageSize);
                ViewBag.PageSize = pageSize;
                ViewBag.Page = page;
            }
            
            if(cate!=null)
            {
                ViewBag.CateName = cate.Title;
            }
            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Partial_itemsByCateId()
        {
            var items = db.Products.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ProductSales()
        {
            var items = db.Products.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }
    }
}