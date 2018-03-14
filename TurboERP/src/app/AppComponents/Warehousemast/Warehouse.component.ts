import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { WarehouseMast} from './Warehouse.model';
import {Comp} from '../Warehousemast/Warehouse.model';
import { Http } from '@angular/http';
@Component({
    templateUrl: 'Warehouse.component.html'
})
export class WarehouseComponent  {
    private GetUrl: any;
    PID: number;
    model=new WarehouseMast(); 
    CompModel:Comp[];
    msg: string;     
    btnText:string="Save";
    selectedValue = '0';
    constructor(private _AppService: AppService,private route: ActivatedRoute,private router:Router,private http:Http) {
        // this.route.url.subscribe((url:any) =>{this.GetUrl=url[1].path;});    
    };
       
    ngOnInit(): void {
        this.BindComp();
        this.GetUrl = this.route.queryParams
        .subscribe(params => {
          // Defaults to 0 if no query param provided.
          this.PID = + params['Id'] || 0;
        }); 
        if(this.PID!=0)
        {
        this.btnText="Update"
        this.LoadWarehouse(this.PID);
        }

    }
    LoadWarehouse(PID): void {
     
        this._AppService.get("http://localhost:52148/api/WarehouseAPI/GetWareHouse?Pid="+PID)
        .subscribe(result => {
           this.model=result;
           this.selectedValue=this.model.COMPANY_PID;
console.log("Edit"+this.model);
        },

        error => this.msg = <any>error);
       
   };

   BindComp(): void {
     
    this.http.get("http://localhost:52148/api/WarehouseAPI/GetCompList")
    .subscribe(result => {
        let Responsedata=JSON.stringify(result.json())
        this.CompModel=JSON.parse(Responsedata)
     //console.log(this.CompModel);
    },

    error => this.msg = <any>error);
   
};

   SaveWarehouse() {
     this.model.COMPANY_PID=this.selectedValue;   
    this.model.PID=this.PID
    if(this.PID!=0){
       this._AppService.put("http://localhost:52148/api/WarehouseAPI/PutWareHouse", this.model)
        .subscribe(
            res => {                
                console.log("Edit"+this.model)
                if(res!=""){
                    this.router.navigate(['/Warehouse']);
                }                
            }
        );
    }
    else{
        this._AppService.post("http://localhost:52148/api/WarehouseAPI/PostWareHouse", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res!=""){
                    this.router.navigate(['/Warehouse']);
                }
            }
        );
        
    }
        
    };


}
