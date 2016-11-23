using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using POSWeb.Models;
using BusinessEntity;
using DataAccess;
using System.Data;
using System.Configuration;

namespace POSWeb.Controllers
{
    public class PurchaseController : Controller
    {
        public List<BusinessEntity.Purchase> plist = new List<BusinessEntity.Purchase>();
        public static string cons = ConfigurationManager.ConnectionStrings["DBConStr"].ConnectionString;
        GetParames _parm = new GetParames();
        GetData _Data = new GetData(cons);

        // GET: Purchase
        public ActionResult Index()
        {
            Session["PurList"] = plist;
            PurchaseModelcs pmodel = new PurchaseModelcs();
            var param = _parm.GetPurchase();
            DataSet ds = _Data.GetDataSetResult(param);
            var list = ds.Tables[0].DataTableToList<BusinessEntity.Purchase>();
            pmodel.lstpurchase = list;
            return View(pmodel);
        }
        [HttpPost]
        public ActionResult Index(PurchaseModelcs pmodle)
        {
            //plist = (List<BusinessEntity.Purchase>)Session["PurList"];
            //plist.Add(new BusinessEntity.Purchase() { Pdate = DateTime.Today.ToString(), MemoNo = pmodle.MemoNo, Remarks = pmodle.Remarks, SupplierId = pmodle.SupplierId ,Total=pmodle.Total});
            //Session["PurList"] = plist;
            //pmodle.Pdate = "";
            //pmodle.MemoNo = "";
            //pmodle.Remarks = "";
            //pmodle.Total = "";
            //foreach (var item in plist)
            //{
            //    pmodle.lstpurchase.Add(item);
            //}

            var param = _parm.AddPurchase(pmodle);
            DataSet ds = _Data.GetDataSetResult(param);
            var list = ds.Tables[0].DataTableToList<BusinessEntity.Purchase>();
            ModelState.Clear();
            pmodle.lstpurchase = list;
            var newmodel = pmodle;

            if (ModelState.IsValid)
            {
                return View("Index", newmodel);
            }
            return View(newmodel);
        }
    }
}