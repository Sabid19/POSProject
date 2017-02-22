using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSWeb.ViewModel;
using DataAccess;
using DataAccess.Repository;

namespace POSWeb.Controllers.Purchase
{
    public class PurchaseEntryController : Controller
    {
        Repository<Supplier> suprep = new Repository<Supplier>();
        Repository<Item> itemrep = new Repository<Item>();
        Repository<DataAccess.Purchase> Purcrep = new Repository<DataAccess.Purchase>();
        // GET: PurchaseEntry
        public ActionResult Index()
        {
            var vm = new PurchaseEntryVM();
            return View(vm);
        }



        public JsonResult PopulateSupplier()
        {
            //holds list of suppliers
            List<Supplier> _supplierList = new List<Supplier>();
            //queries all the suppliers for its ID and Name property.
            var supplierList = (from s in suprep.GetAll()
                                select new { s.ID, s.Name }).ToList();

            //save list of suppliers to the _supplierList
            foreach (var item in supplierList)
            {
                _supplierList.Add(new Supplier
                {
                    ID = item.ID,
                    Name = item.Name
                });
            }
            //returns the Json result of _supplierList
            return Json(_supplierList, JsonRequestBehavior.AllowGet);
        }


        public JsonResult PopulateItem()
        {
            var itemList = (from i in itemrep.GetAll()
                            select new { i.ItemID, i.Name }).ToList();
            //holds the list of item
            List<Item> _item = new List<Item>();

            foreach (var item in itemList)
            {
                _item.Add(new Item
                {
                    ItemID = item.ItemID,
                    Name = item.Name
                });
            }
            //returns the list of item in Json form 
            return Json(_item, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SavePurchase(PurchaseEntryVM p)
        {
            bool status = false;

            if (p != null)
            {
               DataAccess.Purchase purchase = new DataAccess.Purchase
               {
                    ID = p.ID,
                    Date = p.Date,
                    SupplierID = p.SupplierID,
                    Amount = p.Amount,
                    Discount = p.Discount,
                    Tax = p.Tax,
                    GrandTotal = p.GrandTotal,
                    IsPaid = p.IsPaid,
                    Description = p.Description,
                    LastUpdated = DateTime.Now
                };

                purchase.PurchaseItems = new List<PurchaseItem>();
                foreach (var i in p.PurchaseItems)
                {
                    purchase.PurchaseItems.Add(i);
                }

                //add purchase 
                Purcrep.Add(purchase);
                PurchaseEntryRepository pent = new PurchaseEntryRepository();
                foreach (var item in p.PurchaseItems)
                {
                    pent.InsertOrUpdateInventory(item);
                }

                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}