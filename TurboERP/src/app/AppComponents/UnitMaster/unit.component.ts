import { Component,ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { UnitMast } from '../../AppComponents/UnitMaster/unit.model';


@Component({
    templateUrl: 'unit.component.html',
    styleUrls: ['./unit.component.css'],

})
export class UnitComponent  {
    @ViewChild('myForm')
    private myForm: NgForm;
    private GetUrl: any;
    PID: number;
    model=new UnitMast(); 
    msg: string;
    btnText:string="Save";
    unitDisabled="false";

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
        this.unitDisabled="true";
        this.LoadUnit(this.PID);
        }

    }
    LoadUnit(PID): void {
     
        this._AppService.get("http://localhost:52148/api/UnitApi/GetUnit?Pid="+PID)
        .subscribe(result => {
           this.model=result;
            console.log("Edit");
        },

        error => this.msg = <any>error);
       
   };

   getUnit(): void {
    this.router.navigate(['/Unit']);
};
   SaveUnit(valid) {
    console.log(this.model)
    if(this.PID!=0){
       this._AppService.put("http://localhost:52148/api/UnitApi/PutUnit", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res=="1"){
                    alert("Data  updated successfully");
                    this.router.navigate(['/Unit']);
                }
                else{
                    alert(res);
                }
                
            }
        );
    }
    else{
        this._AppService.post("http://localhost:52148/api/UnitApi/PostUnit", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res=="1"){
                    alert("Data  inserted successfully");
                    this.router.navigate(['/Unit']);
                }
                else if(res==""){
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
