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
using DataAccess.Repository;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin.Security;
using System.Security.Claims;
using POSWeb.ViewModel.Account;
using Microsoft.AspNet.Identity.Owin;
using POSWeb.App_Start;
using POSWeb.Models.Account;

namespace POSWeb.Controllers
{
    public class HomeController : Controller
    {
        public static string cons = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
        GetParames _parm = new GetParames();
        GetData _Data = new GetData(cons);
        Repository<Item> rep = new Repository<Item>();

        [Authorize(Roles ="Admin")]
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

            //var param = _parm.login();
            //DataSet ds = _Data.GetDataSetResult(param);

            ViewBag.todaySales = "50"; // TodaySales();
            ViewBag.yesterdaySales = "100";  //YesterdaySales();
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error()
        {
            return View("NotFoundError");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel lmodel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(lmodel);
            }
            ApplicationSignInManager signinManager = Request.GetOwinContext().Get<ApplicationSignInManager>();

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            SignInStatus SigninStatus = signinManager.PasswordSignIn(lmodel.Email, lmodel.Password, lmodel.RememberMe, shouldLockout: false);
            switch (SigninStatus)
            {
                case SignInStatus.Success:
                    return Redirect("Home/Index");           
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(lmodel);
            }
        }

        [Authorize]
        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }
        public ActionResult Product(string currentFilter,string searchString, int? page)
        {
            //ViewBag.CurrentSort = sortOrder;
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            Repository<Item> rep = new Repository<Item>();
            ASITPOSDBEntities db = new ASITPOSDBEntities();

            var kkk = rep.GetAll();
            var ttt = db.Items.ToList();
            var lll = db.Catagories.ToList();
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
            var currencyList = ds.Tables[0].DataTableToList<BusinessEntity.Catagory>();
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