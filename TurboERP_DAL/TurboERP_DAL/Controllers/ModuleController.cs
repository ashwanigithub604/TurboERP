using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurboERP_DAL.Controllers;
using System.Threading.Tasks;
using TurboERP_DAL.Models;
using System.Data;
using TurboERP_DAL.App_DAL;
using Newtonsoft.Json;

namespace TurboERP_DAL.Controllers
{
    //[SessionExpireAttribute]
    public class ModuleController : Controller
    {
        // GET: Module
        public ActionResult Module()
        {
            return View();
        }

        // GET: Module/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Module/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Module/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Module/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Module/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Module/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Module/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Module/Delete/5
        public ActionResult ModulesPermission()
        {
            return View();
        }
        public ActionResult GetPermissionList()
        {
            var moduleListWithActions = new List<GroupModuleList>();

            var moduleList = new ModulesApiController().GetModules();
            foreach (var module in moduleList)
            {
                var moduleData = moduleListWithActions.Where(a => a.Grp_Code == module.Grp_Code).FirstOrDefault();
                if (moduleData != null)
                {
                    var modules = moduleData.Modules.Where(a => a.Mod_Code == module.Mod_Code).FirstOrDefault();
                    if (modules != null)
                    {
                        modules.Actions.Add(new ActionList { Action = module.Action, IsSelected = false });
                    }else
                    {
                        modules=  new ModuleList { Mod_Code = module.Mod_Code, Mod_Name = module.Mod_Code, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false } ;
                        moduleData.Modules.Add(modules);
                    }
                   
                }
                else
                {
                    moduleData = new GroupModuleList();
                    moduleData.Grp_Code = module.Grp_Code;
                    moduleData.Grp_Desc = module.Grp_Desc;
                    moduleData.Modules = new List<ModuleList>() { new ModuleList { Mod_Code = module.Mod_Code, Mod_Name = module.Mod_Code, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false } };
                    moduleListWithActions.Add(moduleData);
                }
                
            }
            return Json(moduleListWithActions, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMenu()
        {
            var moduleListWithActions = new List<MGroupModuleList>();
            string Code = Convert.ToString(Session["Code"]);
            Code = "A000000";
            var moduleList = new ModulesApiController().GetMenu(Code);
            foreach (var module in moduleList)
            {
                var moduleData = moduleListWithActions.Where(a => a.Grp_Code == module.Grp_Code).FirstOrDefault();
                if (moduleData != null)
                {
                    var modules = moduleData.Modules.Where(a => a.Mod_Code == module.Mod_Code).FirstOrDefault();
                    if (modules != null)
                    {
                        var action = new ActionList { Action = module.Action, IsSelected = false };
                        modules.Actions.Add(action);
                        var subModule = modules.SubModuleList.Where(a => a.SubMenu == module.SubMenu).FirstOrDefault();
                        if (subModule != null)
                        {
                            subModule.Actions.Add(action);

                        }
                        else if (module.SubMenu != null)
                        {
                            modules.SubModuleList.Add(new SubModuleList { SubMenu = module.SubMenu, Actions = new List<ActionList>() { action }, IsSelected = false, ActionName = module.ActionName, ControllerName = module.ControllerName });
                        }
                    }
                    else
                    {
                        var subModuleList = module.SubMenu != null ? new List<SubModuleList>() { new SubModuleList { SubMenu = module.SubMenu, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false, ActionName = module.ActionName, ControllerName = module.ControllerName } } : new List<SubModuleList>();
                        modules = new MenuModuleList { Mod_Code = module.Mod_Code, Menu_Desc = module.Menu_Desc, Mod_Name = module.Mod_Code, ControllerName = module.ControllerName, ActionName = module.ActionName, SubModuleList = subModuleList, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false };
                        moduleData.Modules.Add(modules);

                    }
                }
                else
                {


                    moduleData = new MGroupModuleList();
                    moduleData.Grp_Code = module.Grp_Code;
                    moduleData.Grp_Desc = module.Grp_Desc;
                    if (module.Mod_Code == module.Grp_Code) { moduleData.treeview = "treeview"; moduleData.treeviewmenu = "treeview-menu"; }
                    if (module.Active == true) { moduleData.arrow = "fa fa-angle-left pull-right"; moduleData.hrefurl = "#"; } else { moduleData.arrow = ""; moduleData.hrefurl = "../Account/Home"; }


                    var subModuleList = module.SubMenu != null ? new List<SubModuleList>() { new SubModuleList { SubMenu = module.SubMenu, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false, ActionName = module.ActionName, ControllerName = module.ControllerName } } : new List<SubModuleList>();

                    moduleData.Modules = new List<MenuModuleList>() { new MenuModuleList { Mod_Code = module.Mod_Code, Menu_Desc = module.Menu_Desc, Mod_Name = module.Mod_Code, ControllerName = module.ControllerName, ActionName = module.ActionName, SubModuleList = subModuleList, Actions = new List<ActionList>() { new ActionList { Action = module.Action, IsSelected = false } }, IsSelected = false } };
                    moduleListWithActions.Add(moduleData);
                }
            }
            //return Json(JsonConvert.SerializeObject(moduleListWithActions), JsonRequestBehavior.AllowGet);
            return Json(moduleListWithActions, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUserRights(string ch)
        {
            List<UserRight> UsrRightsList = null;
            try
            {
                DataTable userDt = new DataTable();
                userDt = new Pubcls().getUserRights(ch.Trim(), "A000000");
                UsrRightsList = GetList.DataTableToList<UserRight>(userDt);
                return Json(new { userRights = JsonConvert.SerializeObject(UsrRightsList)}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { userRights = JsonConvert.SerializeObject(UsrRightsList) }, JsonRequestBehavior.AllowGet);
            }
        }
      
    }
}
