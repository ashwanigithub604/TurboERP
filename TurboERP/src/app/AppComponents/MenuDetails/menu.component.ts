import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { IMGroupModuleList } from '../../AppModule/Menu/menu';

declare var $:any,fn: any;
@Component({
    selector: 'sidebarMenu',
    templateUrl: 'menu.component.html',
    //styleUrls: ['./menu.component.css'],
    providers: [AppService],
})

export class MenuComponent implements OnInit {

    constructor(private _MenuService: AppService) {

    }
   
    indLoading: boolean = false;
    msg: string;
    Menus: IMGroupModuleList[];
    Menu: IMGroupModuleList;
    selected: any;
    ngOnInit(): void {

        this.LoadMenus();

    }
    LoadMenus(): void {
        this.indLoading = true;
        this._MenuService.get("http://localhost:52148/api/ModulesApi/GetMenu")
            .subscribe(Menus => {
                this.Menus = Menus;
                console.log(this.Menus);
                this.indLoading = false;
            },

            error => this.msg = <any>error);
    };


}

