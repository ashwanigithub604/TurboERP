import { Component } from '@angular/core';
import { Http } from '@angular/http'
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable'
import { ManufacturingUnitModel } from './manufacturing.model'
import { AppService } from '../../AppServices/app.service';


@Component({
    templateUrl: 'manufacturing.component.html'
})

export class ManufacturingUnitComponent {
    private GetUrl: any;
    PID: number;
    msg: string;
    btnText: string = "Save";
    ModelManufactUnit = new ManufacturingUnitModel();
    

    constructor(private _AppService: AppService, private route: ActivatedRoute, private router: Router,private http:Http
    ) { };

    ngOnInit(): void {
        this.GetUrl = this.route.queryParams.subscribe(params => {
            this.PID = + params['Id'] || 0;
        });
        if (this.PID != 0) {
            this.btnText = "Update"
            this.LoadManufacturingUnit(this.PID);
        }
    }

    LoadManufacturingUnit(PID): void {
        this._AppService.get("http://localhost:52148/api/ManufacturingUnitApi/GetManufacturingUnit?Pid=" + PID)
            .subscribe(result => {
                this.ModelManufactUnit = result;
            },
                error => this.msg = <any>error);

    };
    

    SaveManufacturingUnit() {
        console.log(this.ModelManufactUnit)
        if (this.PID != 0) {
            this._AppService.put("http://localhost:52148/api/ManufacturingUnitApi/PutManufacturingUnit", this.ModelManufactUnit)
                .subscribe(
                    res => {
                        if (res != "") {
                            this.router.navigate(['/ManufacturingUnit']);
                            alert("Updated Successfully")
                        }
                        else
                        {
                            alert("Not Updated Something Went Wrong")
                        }
                    }
                );
        }
        else {
            this._AppService.post("http://localhost:52148/api/ManufacturingUnitApi/PostManufacturingUnit", this.ModelManufactUnit)
                .subscribe(
                    res => {
                        console.log(res)
                        if (res == null)
                        {
                            alert("Code can not be Duplicate");
                        }
                        if (res != null) {
                            this.router.navigate(['/ManufacturingUnit']);
                            alert("Saved Successfully");
                        }                        
                    }
                );

        }

    };

}