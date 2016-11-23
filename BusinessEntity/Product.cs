using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Product
    {        
        public string ProductId { get; set; }
        [DisplayName("Product Name :")]
        public string ProductName { get; set; }
        [DisplayName("Catagory :")]
        public string CatagoryId { get; set; }
        [DisplayName("Product Description :")]
        public string ProDesc { get; set; }
        [DisplayName("Cost Price :")]
        public decimal CostPrice { get; set; }
        [DisplayName("Sale Price :")]
        public decimal SalePrice { get; set; }
        [DisplayName("Bar Code :")]
        public string ProBarCode { get; set; }
        public decimal QuantityPerUnit { get; set; }
        public byte[] ProImage { get; set; }

    }
}
