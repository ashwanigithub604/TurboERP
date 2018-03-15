import { Component,ViewChild,Directive, forwardRef, Attribute,OnChanges, SimpleChanges,Input } from '@angular/core';
import { NgForm ,NG_VALIDATORS,Validator,Validators,AbstractControl,ValidatorFn } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { CPMaster } from '../../AppComponents/CPMaster/costprice.model';
@Component({
    templateUrl: 'costprice.component.html',
    styleUrls: ['./costprice.component.css'],
})
export class CostPriceComponent  {
    @ViewChild('myForm')
    private myForm: NgForm;
    private GetUrl: any;
    PID: number;
    model=new CPMaster(); 
    msg: string;
    btnText:string="Save";
    costPriceDisabled="false";

    constructor(private _AppService: AppService,private route: ActivatedRoute,private router:Router ) {
        this.GetUrl = this.route.queryParams.subscribe(params => {
            // Defaults to 0 if no query param provided.
            this.PID = + params['Id'] || 0;
          });   
          this.route.url.subscribe((url:any) =>{this.GetUrl=url[1].path;}); 
    };
       
    ngOnInit(): void { 
        if(this.PID!=0){
        this.btnText="Update"
        this.costPriceDisabled="true";
        this.LoadCPMaster(this.PID);
        }

    }
    LoadCPMaster(PID): void {
     
        this._AppService.get("http://localhost:52148/api/CostPriceApi/GetCostPrice?Pid="+PID)
        .subscribe(result => {
           this.model=result;
            console.log("Edit");
        },

        error => this.msg = <any>error);
       
   };
   getCostPrice(): void {
    this.router.navigate(['/CostPrice']);
};

   SaveCPMaster(valid) {
    console.log(this.model)
    if(this.PID!=0){
       this._AppService.put("http://localhost:52148/api/CostPriceApi/PutCostPrice", this.model)
        .subscribe(
            res => {
                console.log(res)
                
                if(res==1){
                    alert("Data  updated successfully");
                    this.router.navigate(['/CostPrice']);
                }
                else if(res=="Value is duplicate."){
                    alert(res);
                }
                else{
                    alert(res);
                }
                
            }
        );
    }
    else{
        this._AppService.post("http://localhost:52148/api/CostPriceApi/PostCostPrice", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res=="1"){
                    alert("Data inserted successfully");
                    this.router.navigate(['/CostPrice']);
                }
                else if(res=="Either Code or Value is duplicate."){
                    alert(res);
                }
                else{
                    alert(res);
                }
            }
        );
        
    }
        
    };


}
