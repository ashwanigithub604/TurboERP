using TurboERP_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurboERP_DAL.Controllers
{
    public class AccountApiController : Controller
    {
        private TurboEMSEntities db = new TurboEMSEntities();
        public IEnumerable<Usermast> GetLogin(string Login_Name)
        {
            var result = (from Usermast  in db.Usermasts select Usermast).ToList().Where(x=>x.Login_Name == Login_Name);
            return result;
        }
      
    }
}
