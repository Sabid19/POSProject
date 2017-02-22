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
    public class SalesEntryController : Controller
    {
        Repository<Stock> StkRep = new Repository<Stock>();
        SalesEntryRepository slsrepo = new SalesEntryRepository();
        // GET: SalesEntry
        public ActionResult Index()
        {
            return View(StkRep.GetAll().Where(x => x.ExpiryDate > DateTime.Now && x.Qty != 0));
        }

        [HttpPost]
        public JsonResult SerializeFormData(FormCollection _collection, string Total, string Discount, string GrandTotal)
        {
            if (_collection != null)
            {
                string[] _stockID, _qty, _rate, _amt;
                //for salesItem
                _stockID = _collection["StockID"].Split(',');
                _qty = _collection["Qty"].Split(',');
                _rate = _collection["Rate"].Split(',');
                _amt = _collection["Amount"].Split(',');
                //for sales
                decimal _total = Convert.ToDecimal(Total);
                decimal _discount = Convert.ToDecimal(Discount);
                decimal _grandTotal = Convert.ToDecimal(GrandTotal);
                DateTime _date = DateTime.Now;

                //instance of the global class
               // MvcApplication app = new MvcApplication();
                DataAccess.Sale _sales = new DataAccess.Sale()
                {
                    Date = _date,
                    Amount = _total,
                    Discount = _discount,
                    GrandTotal = _grandTotal,
                    Tax = 0,
                   // UserID = User.Identity.Name,
                    Remarks = "-"
                };
                //insert into sales, sales-items, stock
                int salesID = slsrepo.InsertSales(_sales);
                slsrepo.InsertSalesItem(salesID, _stockID, _qty, _rate, _amt);
                slsrepo.UpdateStock(_stockID, _qty);
                return Json(salesID);
            }
            return Json("null");
        }

        //Generates Sales Invoice
        public ActionResult SalesInvoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var _sales = slsrepo.GetSales(id);
            //check if id supplied is present or not.
            if (_sales == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(_sales);
            }

        }


    }
}