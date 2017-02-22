using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess;

namespace POSWeb.ViewModel
{
    public class PurchaseEntryVM
    {

       // ASITPOSDBEntities1 db = new ASITPOSDBEntities1();

        public string ID { get; set; }
        public DateTime Date { get; set; }
        public int SupplierID { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }   
        public decimal GrandTotal { get; set; }
        public bool IsPaid { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public List<PurchaseItem> PurchaseItems { get; set; }

    }
}