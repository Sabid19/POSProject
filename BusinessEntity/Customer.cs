using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
   public class Customer
    {
        public string CustomerId { get; set; }

        [DisplayName("Member Card: ")]
        public string MemberCrd { get; set; }
        [DisplayName("Customer Name: ")]
        public string Cname { get; set; }
        [DisplayName("Address: ")]

        public string CAddress { get; set; }
        [DisplayName("Phone: ")]

        public string CPhone { get; set; }
        [DisplayName("Email: ")]

        public string CEmail { get; set; }
        [DisplayName("Remarks: ")]

        //public string Point { get; set; }

        public string Remarks { get; set; }
       

    }
}
