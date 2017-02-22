using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using BusinessEntity;

namespace POSWeb.Models
{
    public class GetParames
    {
        public SQLParams login()
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "LOGIN";
            par.var01 = "";
            par.var02 = "";           
            return par;
        }

        public SQLParams GetProduct()
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "GETPRODUCT";
            par.var01 = "";
            par.var02 = "";
            return par;
        }

        public SQLParams GetCatagory()
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "GETCATAGORY";
            return par;
        }

        public SQLParams GetAddProduct(Product pro)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "ADDPRODUCT";
            par.var01 = pro.ProductName;
            par.var02 = pro.ProDesc;
            par.var03 = pro.ProBarCode;
            par.var04 = pro.CatagoryId;
            par.var05 = pro.CostPrice.ToString();
            par.var06 = pro.SalePrice.ToString();
            par.var07 = "";
            par.var08 = "0";
            par.var09 = "0";
            par.var10 = "0";
            par.var11 = pro.QuantityPerUnit.ToString();
            return par;
        }

        public SQLParams DeleteProduct(string id)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "DELETEPRODUCT";
            par.var01 = id;
            return par;
        }

        public SQLParams GetSupplier()
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "GETSUPPLIER";
            return par;
        }
        public SQLParams AddSupplier(BusinessEntity.Supplier sup)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "ADDSUPPLIER";
            par.var01 = sup.SupplierId;
            par.var02 = sup.Company_Name;
            par.var03 = sup.Contact_Name;
            par.var04 = sup.Address;
            par.var05 = sup.City.ToString();
            par.var06 = sup.Postal_Code.ToString();
            par.var07 = sup.Country;
            par.var08 = sup.Phone;
            par.var09 = sup.email;
            return par;
        }

        public SQLParams EditSupplier(string id)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "DETAILSSUPPLIER";
            par.var01 = id;
            return par;
        }
        public SQLParams DeleteSupplier(string id)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "DELETESUPPLIER";
            par.var01 = id;
            return par;
        }
        public SQLParams UpdateSupplier(BusinessEntity.Supplier sup)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "EDITSUPPLIER";
            par.var01 = sup.SupplierId;
            par.var02 = sup.Company_Name;
            par.var03 = sup.Contact_Name;
            par.var04 = sup.Address;
            par.var05 = sup.City.ToString();
            par.var06 = sup.Postal_Code.ToString();
            par.var07 = sup.Country;
            par.var08 = sup.Phone;
            par.var09 = sup.email;
            return par;
        }

        #region For Purchase

        public SQLParams GetPurchase()
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "GETPURCHASE";
            return par;
        }

        public SQLParams AddPurchase(PurchaseModelcs pur)
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "ADDPURCHASE";
            par.var01 = pur.Pdate;
            par.var02 = pur.SupplierId;
            par.var03 = pur.MemoNo;
            par.var04 = pur.Total;
            par.var05 = pur.Remarks;

            return par;
        }



        #endregion

        #region for customer

        public SQLParams GetCustomer()
        {
            SQLParams par = new SQLParams();
            par.ProcName = "dbo.COMMON_UTILITY";
            par.Segment = "GETCUSTOMERINFO";
            return par;
        }

        #endregion

    }
}