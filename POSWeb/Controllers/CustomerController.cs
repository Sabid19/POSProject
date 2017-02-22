using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntity;
using System.Configuration;
using POSWeb.Models;
using DataAccess;
using PagedList;

namespace POSWeb.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public static string cons = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
        GetParames _parm = new GetParames();
        GetData _Data = new GetData(cons);
        public ActionResult customer(string currentFilter, string searchString, int? page)
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

            var param = _parm.GetCustomer();
            DataSet ds = _Data.GetDataSetResult(param);
          //  var list = ds.Tables[0].DataTableToList<Customer>();

            if (!String.IsNullOrEmpty(searchString))
            {
               // list = list.Where(s => s.Cname.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View();
        }
    }
}