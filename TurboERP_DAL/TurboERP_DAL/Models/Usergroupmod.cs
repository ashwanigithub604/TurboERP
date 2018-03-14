using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class Usergroupmod
    {
        public int Pid { get; set; }
        public string Usergrp_Code { get; set; }
        public string Mod_Code { get; set; }
        public Nullable<bool> Add_new { get; set; }
        public Nullable<bool> Edit { get; set; }
        public Nullable<bool> View { get; set; }
        public Nullable<bool> Delete { get; set; }
        public Nullable<bool> Print { get; set; }
        public Nullable<bool> Assign { get; set; }
    }
}