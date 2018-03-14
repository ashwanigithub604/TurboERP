using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class Modules
    {
      
            public int Pid { get; set; }
            public string Grp_Code { get; set; }
            public string Grp_Desc { get; set; }
            public string Mod_Code { get; set; }
            public string Mod_Name { get; set; }
            public string Mod_Desc { get; set; }
            public string Menu_Desc { get; set; }
            public string Action { get; set; }
            public Nullable<double> Open_Bal { get; set; }
            public Nullable<double> Total { get; set; }
            public string Mod_Link { get; set; }
            public Nullable<bool> Active { get; set; }
            public Nullable<int> OrdKeyMain { get; set; }
            public Nullable<int> OrdKeyChd { get; set; }
    }
}