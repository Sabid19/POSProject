using DataAccess;
using PagedList;
using POSWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repository;
using System.Net;

namespace POSWeb.Controllers
{
    public class SupplierController : Controller
    {
        Repository<Supplier> SuppRep = new Repository<Supplier>();
        public ActionResult Index()
        {
            return View(SuppRep.GetAll().OrderByDescending(s => s.ID).ToList());
        }

        public ActionResult Supplier(string currentFilter, string searchString, int? page)
        {
            //if (searchString != null)
            //{
            //    page = 1;
            //}
            //else
            //{
            //    searchString = currentFilter;
            //}

            //ViewBag.CurrentFilter = searchString;

            //var param = _parm.GetSupplier();
            //DataSet ds = _Data.GetDataSetResult(param);
            //var list = ds.Tables[0].DataTableToList<BusinessEntity.Supplier>();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    list = list.Where(s => s.Company_Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            //}

            //int pageSize = 5;
            //int pageNumber = (page ?? 1);
            //return View(list.ToPagedList(pageNumber, pageSize));
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
           
            if (ModelState.IsValid)
            {
                int countSupplier = DuplicateCount(supplier);

                if (Request.IsAjaxRequest())
                {
                    if (countSupplier > 0)
                    {
                        ViewBag.DuplicateError = "Already Exists!";
                        return Json("duplicate", JsonRequestBehavior.AllowGet);
                    }
                    SuppRep.Add(supplier);
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                if (countSupplier > 0)
                {
                    ViewBag.DuplicateError = "Already Exists!";
                    return View(supplier);
                }
                //Add supplier to dataSet
                SuppRep.Add(supplier);       
                return RedirectToAction("Index");
            }

            return View(supplier);
        }
        public ActionResult AddSupplier(BusinessEntity.Supplier sup)
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            return View();
        }  

        // GET: Supplier/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = SuppRep.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid && supplier != null)
            {

                var original = SuppRep.GetById(supplier.ID);

                if (original.Name != supplier.Name)
                {
                    int countSupplier = DuplicateCount(supplier);
                    //If already exists. display an error.
                    if (countSupplier > 0)
                    {
                        ViewBag.DuplicateError = "Already Exists!";
                        return View(supplier);
                    }
                }
                SuppRep.Update(original, supplier);

                return RedirectToAction("Index");
               
            }

            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = SuppRep.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = SuppRep.GetById(id);
            SuppRep.Remove(supplier);

            return RedirectToAction("Index");
        }


        // GET: Supplier/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = SuppRep.GetById(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        public ActionResult _SupplierCreatePV()
        {
            return PartialView();
        }


        public int DuplicateCount(Supplier item)
        {
            List<Supplier> _item = (from i in SuppRep.GetAll()
                                where i.Name == item.Name
                                select i).ToList();
            return _item.Count;
        }
    }
}