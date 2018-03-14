import { Component } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { UnitMast } from '../../AppComponents/UnitMaster/unit.model';
@Component({
    templateUrl: 'unit.component.html'
})
export class UnitComponent  {
    private GetUrl: any;
    PID: number;
    model=new UnitMast(); 
    msg: string;
    btnText:string="Save";

    constructor(private _AppService: AppService,private route: ActivatedRoute,private router:Router ) {
        // this.route.url.subscribe((url:any) =>{this.GetUrl=url[1].path;});    
    };
       
    ngOnInit(): void {
        this.GetUrl = this.route.queryParams
        .subscribe(params => {
          // Defaults to 0 if no query param provided.
          this.PID = + params['Id'] || 0;
        }); 
        if(this.PID!=0){
        this.btnText="Update"
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

   SaveUnit() {
    console.log(this.model)
    if(this.PID!=0){
       this._AppService.put("http://localhost:52148/api/UnitApi/PutUnit", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res!=""){
                    this.router.navigate(['/Unit']);
                }
                
            }
        );
    }
    else{
        this._AppService.post("http://localhost:52148/api/UnitApi/PostUnit", this.model)
        .subscribe(
            res => {
                console.log(res)
                if(res!=""){
                    this.router.navigate(['/Unit']);
                }
            }
        );
        
    }
        
    };


}
