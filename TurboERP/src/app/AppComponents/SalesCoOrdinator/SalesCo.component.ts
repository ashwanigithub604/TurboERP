import { Component } from '@angular/core';
import { Http } from '@angular/http'
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable'
import { SalesCoModel } from './SalesCo.model';
import { AppService } from '../../AppServices/app.service';

@Component({

    selector: "SalesCom",
    templateUrl: 'SalesCo.component.html'
})
export class SalesCoordinator {
    PID: number;
    msg: string
    btnText: string = "Save";
    private GetUrl: any;
    SelectedValue: any = 0;
    EditedData: SalesCoModel[];
    model = new SalesCoModel();

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
            this.LoadSalesCoordinator(this.PID);
        }

    }
    LoadSalesCoordinator(PID): void {

        this._AppService.get(this._AppService.getProdUrl() + "/api/SalesCoApi/GetSalesCoordinatorById?PID=" + PID)
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

         this.model.MISCTYPE="M";
        if (this.PID != 0) {
            this.http.put(this._AppService.getProdUrl() + "/api/SalesCoApi/UpdateSalesCoordinator", this.model)
                .subscribe(
                res => {
                    let Response = JSON.stringify(res);
                    let ResponseData = JSON.parse(Response);
                    if (ResponseData.status == 200) {

                        alert("Record updated Sucessfully");
                        this.router.navigate(['/SalesCo']);
                    }
                }
                );
        }
        else {
            if (valid)
                this.http.post(this._AppService.getProdUrl() + "/api/SalesCoApi/InsertSalesCoordinator", this.model)
                    .subscribe(
                    res => {
                        let Response = JSON.stringify(res);
                        let ResponseData = JSON.parse(Response);
                        if (ResponseData.status == 200) {
                            alert("Record Saved Sucessfully");
                            this.router.navigate(['/SalesCo']);
                        }
                    }
                    );
        };
    }


}