using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using DataAccess;

namespace POSWeb.Controllers.Inventory
{
    public class ItemController : Controller
    {
        Repository<Item> rep = new Repository<Item>();
        Repository<Catagory> catRep = new Repository<Catagory>();
        // GET: Item
        public ActionResult Index()
        {
            var items = rep.GetAll();
            return View(items);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = rep.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult Create()
        {
             ViewBag.CategeoryID = new SelectList(catRep.GetAll(), "CatagoryId", "CatagoryName");
            //  ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "ManufacturerName");
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                int count = DuplicateCount(item);
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Item already exists!!";
                    ViewBag.CategeoryID = new SelectList(catRep.GetAll(), "CatagoryId", "CatagoryName");
                    //  ViewBag.DrugGenericNameID = new SelectList(db.DrugGenericNames, "ID", "GenericName", item.DrugGenericNameID);
                    //   ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "ManufacturerName", item.ManufacturerID);
                    return View(item);
                }
                else
                {
                    item.LastUpdated = DateTime.Today;
                    item.ItemID = 1;
                    rep.Add(item);                    
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategeoryID = new SelectList(catRep.GetAll(), "CatagoryId", "CatagoryName");
            // ViewBag.DrugGenericNameID = new SelectList(db.DrugGenericNames, "ID", "GenericName", item.DrugGenericNameID);
            // ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "ManufacturerName", item.ManufacturerID);
            return View(item);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = rep.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategeoryID = new SelectList(catRep.GetAll(), "CatagoryId", "CatagoryName");
            // ViewBag.DrugGenericNameID = new SelectList(db.DrugGenericNames, "ID", "GenericName", item.DrugGenericNameID);
            //  ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "ManufacturerName", item.ManufacturerID);
            return View(item);
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,BarCode,Name,GenericNameID,ManufacturerID,CategeoryID,UnitType,Weight,MeasurementID,AlertQty,Description,LastUpdated")] Item item)
        {
            if (ModelState.IsValid)
            {
                var original = rep.GetById(item.ItemID);

                if (original.Name != item.Name)
                {
                    int count = DuplicateCount(item);

                    if (count > 0)
                    {
                        ViewBag.DuplicateError = "Item already exists!!";
                        return View(item);
                    }
                }
                rep.Update(original, item);
                return RedirectToAction("Index");
            }
            ViewBag.CategeoryID = new SelectList(catRep.GetAll(), "CatagoryId", "CatagoryName");
            // ViewBag.DrugGenericNameID = new SelectList(db.DrugGenericNames, "ID", "GenericName", item.DrugGenericNameID);
            // ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "ManufacturerName", item.ManufacturerID);
            return View(item);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = rep.GetById(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }



        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = rep.GetById(id);
            rep.Remove(item);
           // db.SaveChanges();
            return RedirectToAction("Index");
        }


        public int DuplicateCount(Item item)
        {
            List<Item> _item = (from i in rep.GetAll()
                                where i.Name == item.Name
                                select i).ToList();
            return _item.Count;
        }

    }
    }