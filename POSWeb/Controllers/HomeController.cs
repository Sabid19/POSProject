using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using POSWeb.Models;
using BusinessEntity;
using PagedList;

namespace POSWeb.Controllers
{
    public class HomeController : Controller
    {
        public static string cons = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
        GetParames _parm = new GetParames();
        GetData _Data = new GetData(cons);
        // GET: Home
        public ActionResult Index()
        {
            #region SQL Connection
            ////string cStr = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
            ////SqlConnection con=new SqlConnection(cStr);
            //string str = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
            //DataSet ds = new DataSet();
            //using (SqlConnection conn = new SqlConnection(str))
            //{
            //    SqlCommand sqlComm = new SqlCommand("dbo.COMMON_UTILITY", conn);
            //    sqlComm.Parameters.AddWithValue("@ProcID", "LOGIN");


            //    sqlComm.CommandType = CommandType.StoredProcedure;

            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = sqlComm;

            //    da.Fill(ds);
            //}
            #endregion

            var param = _parm.login();
            DataSet ds = _Data.GetDataSetResult(param);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Product(string currentFilter,string searchString, int? page)
        {
            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var param = _parm.GetProduct();
            DataSet ds = _Data.GetDataSetResult(param);
            var list = ds.Tables[0].DataTableToList<Product>();

            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.ProductName.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
          
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            var pap = _parm.GetCatagory();
            DataSet ds = _Data.GetDataSetResult(pap);
           var currencyList = ds.Tables[0].DataTableToList<Catagory>();
            ViewBag.Catagory = currencyList.Select(x => new SelectListItem() { Value = x.catagoriid.ToString(), Text = x.catagoryname }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product pro)
        {
            var param = _parm.GetAddProduct(pro);
            DataSet ds = _Data.GetDataSetResult(param);
            return RedirectToAction("Product");
        }

        public ActionResult DeletProduct(string id)
        {
            var param = _parm.DeleteProduct(id);
            DataSet ds = _Data.GetDataSetResult(param);
            return RedirectToAction("Product");
        }
    }
}