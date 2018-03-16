import { Component,ViewChild ,ElementRef} from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';
import { BuyerMast } from '../../AppComponents/BuyerMaster/buyer.model';
import {CountryMasterModel}  from '../CountryMaster/country.model';
import{CourierModel} from '../Courier/Courier.model'


@Component({
    templateUrl: 'buyer.component.html',
    styleUrls: ['./buyer.component.css'],

})
export class BuyerComponent  {
    @ViewChild('myForm')
    private myForm: NgForm;
    private GetUrl: any;
    PID: number;
    public countryModel: CountryMasterModel[] = [];
    public courierModel: CourierModel[] = [];
    SelectedValue:any=0;
    model=new BuyerMast(); 
    msg: string;
    btnText:string="Save";
    buyertDisabled="false";
    i:number;
    

    constructor(private _AppService: AppService,private route: ActivatedRoute,private router:Router,private elem: ElementRef ) {
        this.GetUrl = this.route.queryParams.subscribe(params => {
          // Defaults to 0 if no query param provided.
          this.PID = + params['Id'] || 0;
        });   
        this.route.url.subscribe((url:any) =>{this.GetUrl=url[1].path;});
        //this.conutryModel.CONT_CODE=this.SelectedValue.toString(); 
    };
       
    ngOnInit(): void {
        this.LaodCountry();
        this.LaodCourier();
        if(this.PID!=0){
        this.btnText="Update"
        this.buyertDisabled="true";
        this.LoadBuyer(this.PID);
        }

    }
    LoadBuyer(PID): void {
     
        this._AppService.get("http://localhost:52148/api/BuyerApi/GetBuyer?Pid="+PID)
        .subscribe(result => {
           this.model=result;
            console.log("Edit");
        },

        error => this.msg = <any>error);
       
   };
   LaodCountry(): void {
     
    this._AppService.get("http://localhost:52148/CountryMast")
    .subscribe(result => {
      
        for(this.i=0;this.i<result.length;this.i++)
        {
            var country=new CountryMasterModel();
           country.CONT_CODE=result[this.i]["Country Name"];
           country.COUN_NAME=result[this.i]["Country Name"];
           this.countryModel.push( country);
        }
       
       
        console.log(this.countryModel);
    },

    error => this.msg = <any>error);
   
};


LaodCourier(): void {
     
    this._AppService.get("http://localhost:52148/api/CourierApi/GetCourierByIden?identifier="+"")
    .subscribe(result => {
         // this.conutryModel=result;
        // for(this.i=0;this.i<result.length;this.i++)
        // {
        //     var courier=new CourierModel();
        //     courier.NAME=result[this.i]["Country Name"];
        //     courier.SHORT_NAME=result[this.i]["Country Name"];
        //    this.conutryModel.push( country);
        // }
       
       
        //console.log(this.conutryModel);
    },

    error => this.msg = <any>error);
   
};
// GetCounCodeId(coun_code){
// this.conutryModel.COUN_CODE=coun_code;
// }

   getBuyer(): void {
    this.router.navigate(['/Buyer']);
};
   SaveBuyer(valid) {
    console.log(this.model)
    if(this.PID!=0){
       this._AppService.put("http://localhost:52148/api/BuyerApi/PutBuyer", this.model)
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
        this._AppService.post("http://localhost:52148/api/BuyerApi/PostBuyer", this.model)
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

    imageupload(){
        let files = this.elem.nativeElement.querySelector('#imgInp').files;
        let formData = new FormData();
        let file = files[0];
        
        formData.append('imgInp', file, file.name);
        //this._AppService.UploadImage(formData).subscribe(res=> '');
        }

}
