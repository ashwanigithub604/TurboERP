import { Component } from '@angular/core';
import { Http } from '@angular/http'
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable'
import{CourierModel} from'./Courier.model'
import { AppService } from '../../AppServices/app.service';

@Component({

    selector: "Courier",
    templateUrl: 'Courier.component.html'
})
export class Couriercomponent {
    PID: number;
    msg: string
    btnText: string = "Save";
    private GetUrl: any;
    EditedData: CourierModel[];
    model = new CourierModel();

    constructor(
       
        private _AppService: AppService, private http:
            Http, private route: ActivatedRoute, private router: Router) {

    }
    ngOnInit(): void {
        this.GetUrl = this.route.queryParams
            .subscribe(params => {
                // Defaults to 0 if no query param provided.
                this.PID = + params['Id'] || 0;
            });
        if (this.PID != 0) {
            this.btnText = "Update"
            this.LoadCourier(this.PID);
        }

    }
    LoadCourier(PID): void {

        this._AppService.get(this._AppService.getProdUrl() + "/api/CourierApi/GetCourierById?PID=" + PID)
            .subscribe(res => {

                let Responsedata = JSON.stringify(res);
                this.EditedData = JSON.parse(Responsedata);
                console.log(this.EditedData)
                this.model = this.EditedData[0]

                // let dateString = this.model.RELA
                // let newDate = new Date(dateString);
                
            },

            error => this.msg = <any>error);
    };
    onSubmit(valid) {
        this.model.MISCTYPE="C"

        if (this.PID != 0) {
            this.http.put(this._AppService.getProdUrl() + "/api/CourierApi/UpdateCourier", this.model)
                .subscribe(
                res => {
                    let Response = JSON.stringify(res);
                    let ResponseData = JSON.parse(Response);
                    if (ResponseData.status == 200) {

                        alert("Record updated Sucessfully");
                        this.router.navigate(['/Courier']);
                    }
                }
                );
        }
        else {
            if (valid)
                this.http.post(this._AppService.getProdUrl() + "/api/CourierApi/InsertCourier", this.model)
                    .subscribe(
                    res => {
                        let Response = JSON.stringify(res);
                        let ResponseData = JSON.parse(Response);
                        if (ResponseData.status == 200) {
                            alert("Record Saved Sucessfully");
                            this.router.navigate(['/Courier']);
                        }
                    }
                    );
        };
    }


}