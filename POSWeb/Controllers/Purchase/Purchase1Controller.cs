using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data;
using DataAccess;
using DataAccess.Repository;
using System.Net;

namespace POSWeb.Controllers.Purchase
{
    public class Purchase1Controller : Controller
    {
        Repository<DataAccess.Purchase> PurchRep = new Repository<DataAccess.Purchase>();
        Repository<PurchaseItem> PurItem = new Repository<PurchaseItem>();
        Repository<Supplier> SuppItem = new Repository<Supplier>();
        // GET: Purchase1
        public ActionResult Index()
        {
            var purchases = PurchRep.GetAll().AsQueryable().Include(p => p.Supplier);
            return View(purchases.ToList());
        }

       // GET: Purchase/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var _purchase = from p in PurItem.GetAll()
                            where p.PurchaseID == id
                            select p;
            if (_purchase == null)
            {
                return HttpNotFound();
            }
            return View(_purchase.ToList());
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var purchase = PurchRep.GetById(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(SuppItem.GetAll(), "ID", "Name", purchase.SupplierID);
            return View(purchase);
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,SupplierID,Amount,Discount,Tax,GrandTotal,IsPaid,LastUpdated,Description")] DataAccess.Purchase purchase)
        {
            if (ModelState.IsValid)
            {
              //  PurchRep.Update(purchase);
               // db.Entry(purchase).State = EntityState.Modified;
               // db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(SuppItem.GetAll(), "ID", "Name", purchase.SupplierID);
            return View(purchase);
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           DataAccess.Purchase purchase = PurchRep.GetById(Convert.ToInt32(id));
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DataAccess.Purchase purchase = PurchRep.GetById(Convert.ToInt32(id));
            PurchRep.Remove(purchase);          
            return RedirectToAction("Index");
        }

    }
}