//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TurboERP_DAL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CPMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPMaster()
        {
            this.ItemMasters = new HashSet<ItemMaster>();
        }
    
        public int PID { get; set; }
        public string CP_CODE { get; set; }
        public Nullable<decimal> NKEY { get; set; }
        public string RATE { get; set; }
        public string INPUT_BY { get; set; }
        public Nullable<System.DateTime> INPUT_DATE { get; set; }
        public string EDIT_BY { get; set; }
        public Nullable<System.DateTime> EDIT_DATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMaster> ItemMasters { get; set; }
    }
}
