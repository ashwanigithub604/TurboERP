import { Component } from '@angular/core';
import { Http } from '@angular/http'
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable'
import { CountryMasterModel, ContinentModel } from './country.model'
import { AppService } from '../../AppServices/app.service';


@Component({
    templateUrl: 'Country.component.html'
})

export class CountryMastComponent {
    private GetUrl: any;
    PID: number;
    msg: string;
    btnText: string = "Save";
    ModelCountry = new CountryMasterModel();
    ModelContinent: ContinentModel[];
    selectedvalue:any="0";
    constructor(private _AppService: AppService, private route: ActivatedRoute, private router: Router, private http: Http
    ) { };

    ngOnInit(): void {
        this.GetContinent();
        this.GetUrl = this.route.queryParams.subscribe(params => {
            this.PID = + params['Id'] || 0;
        });
        if (this.PID != 0) {
            this.btnText = "Update"
            this.LoadCountry(this.PID);
        }
    }

    LoadCountry(PID): void {
        this._AppService.get("http://localhost:52148/api/CountryMastApi/GetCountry?Pid=" + PID)
            .subscribe(result => {
                this.ModelCountry = result;
                this.selectedvalue=this.ModelCountry.CONT_CODE;
            },
                error => this.msg = <any>error);

    };
    GetContinent(): void {
        this.http.get("http://localhost:52148/api/CountryMastApi/GetContinentalCode")
            .subscribe(result => {
                let Responsedata = JSON.stringify(result.json())
                this.ModelContinent = JSON.parse(Responsedata)
            },
                error => this.msg = <any>error);

    };


    SaveCountry() {
        this.ModelCountry.CONT_CODE=this.selectedvalue;
        if (this.PID != 0) {
            this._AppService.put("http://localhost:52148/api/CountryMastApi/PutCountry", this.ModelCountry)
                .subscribe(
                    res => {
                        if (res != "") {
                            this.router.navigate(['/CountryMast']);
                        }

                    }
                );
        }
        else {
            this._AppService.post("http://localhost:52148/api/CountryMastApi/PostCountry", this.ModelCountry)
                .subscribe(
                    res => {
                        if (res != "") {
                            this.router.navigate(['/CountryMast']);
                        }
                    }
                );

        }

    };

}