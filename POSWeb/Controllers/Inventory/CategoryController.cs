using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repository;

namespace POSWeb.Controllers.Inventory
{
    public class CategoryController : Controller
    {
        Repository<Catagory> catRep = new Repository<Catagory>();
        // GET: Category
        public ActionResult Index()
        {
            var catL = catRep.GetAll().ToList();
            return View(catL);
        }

        public ActionResult Create()
        {          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Catagory Cat)
        {
            if (ModelState.IsValid)
            {
                var count = CheckDuplicate(Cat);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Item already exists!!";
                    return View(Cat);
                }
                else
                {
                    catRep.Add(Cat);
                    return RedirectToAction("Index");
                }
            }
            return View(Cat);
        }
        private int CheckDuplicate(Catagory cata)
        {
            var catlst = (from s in catRep.GetAll() where s.CatagoryName == cata.CatagoryName select s).ToList();
            return catlst.Count();
        }
       
    }
}