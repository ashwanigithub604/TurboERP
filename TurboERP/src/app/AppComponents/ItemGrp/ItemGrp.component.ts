import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import {ItemGrpModel} from './ItemGrp.Model'
import { Http } from '@angular/http';
import { AppService } from '../../AppServices/app.service';


@Component({
    selector:"ItemGrp",
    templateUrl:'ItemGrp.component.html'
})

export class ItemGrpComponent  {
    private GetUrl: any;
    PID: number;
    model=new ItemGrpModel();
    Editeddata:ItemGrpModel[]; 
    msg: string;
    btnText:string="Save";

    constructor(private _AppService: AppService,private route: ActivatedRoute,private router:Router,private http:Http ) {
        this.GetUrl = this.route.queryParams.subscribe(params => {
          // Defaults to 0 if no query param provided.
          this.PID = + params['Id'] || 0;
        });   
        this.route.url.subscribe((url:any) =>{this.GetUrl=url[1].path;}); 
    };

    ngOnInit(): void {
         
        if(this.PID!=0){
        this.btnText="Update"
        this.LoadItemGrp(this.PID);
        }

    }
    LoadItemGrp(PID): void {
     
        this._AppService.get("http://localhost:52148/api/ItemGrpApi/GetItemGrp?PID="+PID)
        .subscribe(result => {
            let responsedata=JSON.stringify(result)
            this.Editeddata=JSON.parse(responsedata)
            this.model=this.Editeddata[0];
        //    this.model=result;
        //     console.log("Edit");
        },

        error => this.msg = <any>error);
   };

   SaveItemGrp() {
    console.log(this.model)
    if(this.PID!=0){
       this.http.put("http://localhost:52148/api/ItemGrpApi/PutItemGrp", this.model)
        .subscribe(
            res => {
                let responsedata=JSON.stringify(res)
                let data=JSON.parse(responsedata)
                console.log(data)
                if(data.status==200){
                    this.router.navigate(['/ItemGrp']);
                }
                
            }
        );
    }
    else{
        this._AppService.post("http://localhost:52148/api/ItemGrpApi/PostItemGrp", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res!=""){
                    this.router.navigate(['/ItemGrp']);
                }
            }
        );
        
    }
        
    };

}