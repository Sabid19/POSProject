//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticeJS
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLCATAGORY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLCATAGORY()
        {
            this.TBLPRODUCTs = new HashSet<TBLPRODUCT>();
        }
    
        public int CatagoriId { get; set; }
        public string CatagoryName { get; set; }
        public string CDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPRODUCT> TBLPRODUCTs { get; set; }
    }
}
