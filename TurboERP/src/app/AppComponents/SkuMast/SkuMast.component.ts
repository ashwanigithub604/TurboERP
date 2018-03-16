import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { Http } from '@angular/http';
import {SkuMastModel} from './SkuMast.Model'

@Component({
    selector:"SkuMastBuyer",
    templateUrl:'SkuMast.component.html'
})

export class SkuMastComponent  {
    private GetUrl: any;
    PID: number;
    model=new SkuMastModel();
    Editeddata:SkuMastModel[]; 
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
        this.LoadSkuMast(this.PID);
        }

    }
    LoadSkuMast(PID): void {
     
        this._AppService.get(this._AppService.getProdUrl()+"/api/SkuMastApi/GetSkuMast?PID="+PID)
        .subscribe(result => {
            let responsedata=JSON.stringify(result)
            this.Editeddata=JSON.parse(responsedata)
            this.model=this.Editeddata[0];
            console.log(result);
        //    this.model=result;
        //     console.log("Edit");
        },

        error => this.msg = <any>error);
   };

   SaveSkuMast() {
    console.log(this.model)
    if(this.PID!=0){
       this.http.put(this._AppService.getProdUrl()+"/api/SkuMastApi/PutSkuMast", this.model)
        .subscribe(
            res => {
                let responsedata=JSON.stringify(res)
                let data=JSON.parse(responsedata)
                console.log(data)
                if(data.status==200){
                    this.router.navigate(['/SkuMastBuyer']);
                }
                
            }
        );
    }
    else{
        this._AppService.post(this._AppService.getProdUrl()+"/api/SkuMastApi/PostSkuMast", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res!=""){
                    this.router.navigate(['/SkuMastBuyer']);
                }
            }
        );
        
    }
        
    };

}