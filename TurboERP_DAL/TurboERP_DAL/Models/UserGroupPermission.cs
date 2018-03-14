using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurboERP_DAL.Models
{
    public class UserGroupPermission
    {
        public Usergroup Usergroup { get; set; }
        public List<GroupModuleList> GroupModuleList { get; set; }
    }
}