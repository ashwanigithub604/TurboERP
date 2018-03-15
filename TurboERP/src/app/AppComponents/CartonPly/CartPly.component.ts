import { Component,ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http } from '@angular/http'
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms'
import { CartPlyModel } from './CartPly.model'
import { AppService } from '../../AppServices/app.service';

@Component({
    selector: "CartPly",
    templateUrl: 'CartPly.component.html'

})

export class CartPlycomponent {
    ResultData: any
    PID: number;
    btnText: string = "Save";
    private GetUrl: any;
    msg: string;
    isDuplicate: boolean
    EditedData: CartPlyModel[];
    model = new CartPlyModel();
    constructor(private _AppService: AppService, private http: Http,
        private route: ActivatedRoute, private router: Router) {
            

    }

//     @ViewChild('myForm')
//    private myForm: NgForm;



    ngOnInit(): void {
        this.GetUrl = this.route.queryParams
            .subscribe(params => {
                // Defaults to 0 if no query param provided.
                this.PID = + params['Id'] || 0;
            });
        if (this.PID != 0) {
            this.btnText = "Update"
            this.LoadCartPly(this.PID);
        }
        this.isDuplicate = false

    }
    LoadCartPly(PID): void {

        this._AppService.get(this._AppService.getProdUrl()+"/api/CartonPlyApi/EditCartPly?PID=" + PID)
            .subscribe(res => {

                let Responsedata = JSON.stringify(res);
                this.EditedData = JSON.parse(Responsedata);
                
                console.log(this.EditedData)
                this.model = this.EditedData[0]
            },

                error => this.msg = <any>error);

    };

    onSubmit(valid) {
      
        
        if (this.PID != 0) {
            this.http.put(this._AppService.getProdUrl()+"api/CartonPlyApi/PutCartonPly", this.model)
                .subscribe(
                    res => {
                        let Response = JSON.stringify(res);
                        let ResponseData = JSON.parse(Response);
                        if (ResponseData.status == 200) {

                            alert("Record Updated Sucessfully");
                            this.router.navigate(['/CartonPly']);
                        }
                    }
                );
        }
        else
        {
           if(valid)
           {
            this.http.post(this._AppService.getProdUrl()+"/api/CartonPlyApi/PostCartonPly", this.model)
                .subscribe(
                    res => {
                        //let Responsewithcode=JSON.stringify(res);
                        let Response = JSON.stringify(res.json());
                        //let Responsecodejson=JSON.parse(Responsewithcode);
                        let ResponseData = JSON.parse(Response);
                        //console.log(Responsecodejson.status)
                        if (ResponseData=="S") 
                        {
                         
                            //alert("Record Saved Sucessfully");
                            this.router.navigate(['/CartonPly']);
                        }
                        if(ResponseData=="D")
                         {
                           this.isDuplicate=true;
                            //alert("CartonPly Already Exist");
                         }
                        // else  
                        // {
                        //     alert("CartonPly Already Exist");
                        //     //this.router.navigate(['/CartonPly']);
                        // }
                        
                    }
                );
            }
        }

    };



}