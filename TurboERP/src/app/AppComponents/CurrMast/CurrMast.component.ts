import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { Http } from '@angular/http';
import {CurrMastModel} from './CurrMast.Model'


@Component({
    selector:"CurrMast",
    templateUrl:'CurrMast.component.html'
})

export class CurrMastComponent  {
    private GetUrl: any;
    PID: number;
    model=new CurrMastModel();
    Editeddata:CurrMastModel[]; 
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
        this.LoadCurrMast(this.PID);
        }

    }
    LoadCurrMast(PID): void {
     
        this._AppService.get(this._AppService.getProdUrl()+"/api/CurrMastApi/GetCurrMast?PID="+PID)
        .subscribe(result => {
            let responsedata=JSON.stringify(result)
            this.Editeddata=JSON.parse(responsedata)
            this.model=this.Editeddata[0];
        //    this.model=result;
        //     console.log("Edit");
        },

        error => this.msg = <any>error);
   };

   SaveCurrMast() {
    console.log(this.model)
    if(this.PID!=0){
       this.http.put(this._AppService.getProdUrl()+"/api/CurrMastApi/PutCurrMast", this.model)
        .subscribe(
            res => {
                let responsedata=JSON.stringify(res)
                let data=JSON.parse(responsedata)
                console.log(data)
                if(data.status==200){
                    this.router.navigate(['/Currency']);
                }
                
            }
        );
    }
    else{
        this._AppService.post(this._AppService.getProdUrl()+"/api/CurrMastApi/PostCurrMast", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res!=""){
                    this.router.navigate(['/Currency']);
                }
            }
        );
        
    }
        
    };



}