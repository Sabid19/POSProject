using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using DataAccess;
using System.Data.Entity;
using System.Net;

namespace POSWeb.Controllers.Inventory
{
    public class StockController : Controller
    {
        Repository<Stock> stkrepo = new Repository<Stock>();
        Repository<Item> itemrep = new Repository<Item>();
        ASITPOSDBEntities db = new ASITPOSDBEntities();
        // GET: Stock
        public ActionResult Index()
        {
            var stklst = stkrepo.GetAll().AsQueryable();
            var stocks = stklst.Where(s => s.Qty > 0).Include(s => s.Item).OrderByDescending(x => x.ID);
            return View(stocks.ToList());
        }

        // GET: Stock/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(itemrep.GetAll(), "ItemID", "Name");
            return View();
        }

        // POST: Stock/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ItemID,BatchNo,Qty,CostPrice,SellingPrice,ManufacturedDate,ExpiryDate")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                stkrepo.Add(stock);
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(itemrep.GetAll(), "ItemID", "Name");
            //return back to create view
            return View(stock);
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = stkrepo.GetById(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(itemrep.GetAll(), "ItemID", "Name", stock.ItemID);
            return View(stock);
        }


        // POST: Stock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ItemID,BatchNo,Qty,CostPrice,SellingPrice,ManufacturedDate,ExpiryDate")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                var original = stkrepo.GetById(stock.ID);
                stkrepo.Update(original, stock);
                //db.Entry(stock).State = EntityState.Modified;
               // db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(itemrep.GetAll(), "ID", "Name", stock.ItemID);
            return View(stock);
        }

        // GET: Stock/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = stkrepo.GetById(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Stock/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = stkrepo.GetById(id);
            stkrepo.Remove(stock);
            //save changes
          //  db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Stock/Details/5
        public ActionResult Details(int id)
        {
            //checks if id is null
            if (id == null)
            {
                //returns BadRequest Page 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = stkrepo.GetById(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

    }

}