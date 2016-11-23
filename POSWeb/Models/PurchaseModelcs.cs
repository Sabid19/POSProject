using BusinessEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace POSWeb.Models
{
    public class PurchaseModelcs
    {
        [DisplayName("Memo :")]
        public string MemoNo { get; set; }
        [DisplayName("Supplier :")]
        public string SupplierId { get; set; }
        [DisplayName("Total :")]
        public string Total { get; set; }
        public string Pdate { get; set; }
        [DisplayName("Remarks :")]
        public string Remarks { get; set; }
        public List<Purchase> lstpurchase { get; set; }

        public PurchaseModelcs()
        {
            lstpurchase = new List<Purchase>();
        }

    }
}