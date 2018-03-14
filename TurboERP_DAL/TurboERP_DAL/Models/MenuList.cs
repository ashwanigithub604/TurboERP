using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class MGroupModuleList  
    {
        public string Grp_Code { get; set; }
        public string Grp_Desc { get; set; }
        public string treeview { get; set; }
        public string treeviewmenu { get; set; }
        public string arrow { get; set; }
        public string hrefurl { get; set; }
        public List<MenuModuleList> Modules { get; set; }
        public bool IsSelected { get; set; }
    }
    public class MenuModuleList 
    {
        public string Mod_Code { get; set; }
        public string Mod_Name { get; set; }
        public string Menu_Desc  { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<SubModuleList> SubModuleList { get; set; }
        public List<ActionList> Actions { get; set; }
        public bool IsSelected { get; set; }
    }
 
}