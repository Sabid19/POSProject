using BusinessEntity;
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

namespace POSWeb.Controllers
{
    public class SupplierController : Controller
    {
        // GET: Supplier
        public static string cons = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
        GetParames _parm = new GetParames();
        GetData _Data = new GetData(cons);
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Supplier(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var param = _parm.GetSupplier();
            DataSet ds = _Data.GetDataSetResult(param);
            var list = ds.Tables[0].DataTableToList<Supplier>();

            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Company_Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult AddSupplier(Supplier sup)
        {
            var param = _parm.AddSupplier(sup);
            DataSet ds = _Data.GetDataSetResult(param);
            return RedirectToAction("Supplier");
        }

        public ActionResult Edit(string id)
        {
            var param = _parm.EditSupplier(id);
            DataSet ds = _Data.GetDataSetResult(param);
            Supplier sup = new BusinessEntity.Supplier()
            {
                SupplierId = ds.Tables[0].Rows[0]["SupplierId"].ToString(),
                Company_Name = ds.Tables[0].Rows[0]["Company_Name"].ToString(),
                Contact_Name = ds.Tables[0].Rows[0]["Contact_Name"].ToString(),
                Address = ds.Tables[0].Rows[0]["Address"].ToString(),
                City = ds.Tables[0].Rows[0]["City"].ToString(),
                Postal_Code = ds.Tables[0].Rows[0]["Postal_Code"].ToString(),
                Country = ds.Tables[0].Rows[0]["Country"].ToString(),
                Phone = ds.Tables[0].Rows[0]["Phone"].ToString(),
                email = ds.Tables[0].Rows[0]["email"].ToString()

            };
            return View(sup);
        }
        public ActionResult Delete(string id)
        {
            var param = _parm.DeleteSupplier(id);
            DataSet ds = _Data.GetDataSetResult(param);
            return RedirectToAction("Supplier");
        }
        public ActionResult Update(Supplier sup)
        {
            var param = _parm.UpdateSupplier(sup);
            DataSet ds = _Data.GetDataSetResult(param);
            return RedirectToAction("Supplier");
        }
    }
}