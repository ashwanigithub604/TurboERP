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
    
    public partial class ModelSL
    {
        public int PID { get; set; }
        public string VEH_CODE { get; set; }
        public string MODEL_CODE { get; set; }
        public string MODEL_SL { get; set; }
        public string INPUT_BY { get; set; }
        public Nullable<System.DateTime> INPUT_DATE { get; set; }
        public string EDIT_BY { get; set; }
        public Nullable<System.DateTime> EDIT_DATE { get; set; }
    
        public virtual Model Model { get; set; }
        public virtual VehiMast VehiMast { get; set; }
    }
}
