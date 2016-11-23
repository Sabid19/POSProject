using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public class Purchase
    {
            public string MemoNo { get; set; }
            public string SupplierId { get; set; }
            public string Total { get; set; }
            public string Pdate { get; set; }
            public string Remarks { get; set; }
    }
}
