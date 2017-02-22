using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.Repository;
using System.Net;

namespace POSWeb.Controllers.Sales
{
    public class SalesController : Controller
    {
        Repository<Sale> salRepo = new Repository<Sale>();
        Repository<SalesItem> salItemRepo = new Repository<SalesItem>();
        // GET: Sales
        public ActionResult Index()
        {
            var sal = salRepo.GetAll().OrderByDescending(s => s.ID).ToList();
            return View(sal);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _salesItems = (from si in salItemRepo.GetAll()
                               where si.SalesID == id
                               select si).ToList();

            if (_salesItems == null)
            {
                return HttpNotFound();
            }
            return View(_salesItems.ToList());
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sales = salRepo.GetById(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);
        }

        // POST: Sales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,Amount,Discount,Tax,GrandTotal,UserID,Remarks")]DataAccess.Sale sales)
        {
            if (ModelState.IsValid)
            {
                var original = salRepo.GetAll().ToList().Find(x => x.ID == sales.ID);
                salRepo.Update(original, sales);
               // db.Entry(sales).State = EntityState.Modified;
              //  db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sales);
        }
    }
}