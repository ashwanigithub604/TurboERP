export interface IActionList {
     Action: string,
     IsSelected: boolean,
}

export interface ISubModuleList {
     SubMenu: string,
     Menu_Desc: string,
     IsSelected: boolean,
     ControllerName: string,
     ActionName: string,
     Actions: IActionList[],
}

export interface IMenuModuleList {
     Mod_Code: string,
     Mod_Name: string,
     Menu_Desc: string,
     ControllerName: string,
     ActionName: string,
     Actions: IActionList[],
     SubModuleList: ISubModuleList[],
     IsSelected: boolean,
}
export interface IMGroupModuleList {
     Grp_Code: string,
     Grp_Desc: string,
     treeview: string,
     treeviewmenu: string,
     arrow: string,
     hrefurl: string,
     Modules: IMenuModuleList[],
     IsSelected: boolean
}


