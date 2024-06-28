using ClothesWeb.Models;
using ClothesWeb.Models.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothesWeb.Areas.Admin.Controllers
{
    
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        public ActionResult Index()
        {
            var items = db.Roles.ToList();
            return View(items);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole model)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                roleManager.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}