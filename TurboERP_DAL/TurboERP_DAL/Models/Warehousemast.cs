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
    
    public partial class Warehousemast
    {
        public int PID { get; set; }
        public Nullable<int> COMPANY_PID { get; set; }
        public string WAREHOUSE_NAME { get; set; }
        public string ADDRESS { get; set; }
        public string ADD_BY { get; set; }
        public string EDIT_BY { get; set; }
        public Nullable<System.DateTime> EDIT_DT { get; set; }
        public Nullable<System.DateTime> ENTRY_DT { get; set; }
    
        public virtual Company Company { get; set; }
    }
}
