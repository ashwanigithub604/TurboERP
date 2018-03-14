using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class UserModule
    {
        public int Pid { get; set; }
        public string User_Code { get; set; }
        public string Mod_Code { get; set; }
        public Nullable<bool> AddNew { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> View { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> Print { get; set; }
        public Nullable<bool> Assign { get; set; }
    }
}