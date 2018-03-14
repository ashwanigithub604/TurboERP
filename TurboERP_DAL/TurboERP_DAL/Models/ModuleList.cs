using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class GroupModuleList
    {
        public string Grp_Code { get; set; }
        public string Grp_Desc  { get; set; }
        public List<ModuleList> Modules { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ModuleList
    {
        public string Mod_Code { get; set; }
        public string Mod_Name { get; set; }
        public string Menu_Desc { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<ActionList> Actions { get; set; }
        public List<SubModuleList> SubModuleList  { get; set; }
        public bool IsSelected { get; set; }
    }
    public class ActionList
    {
        public string Action { get; set; }
        public bool IsSelected { get; set; }
    }
    public class SubModuleList
    {
        public string SubMenu { get; set; }
        public string Menu_Desc { get; set; }
        public bool IsSelected { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<ActionList> Actions { get; set; }
    }
}