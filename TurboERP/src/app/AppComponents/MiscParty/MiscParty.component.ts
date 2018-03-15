import { Component } from '@angular/core';
import { Http } from '@angular/http'
import { Router, ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs/Observable'
import { MiscPartyModel } from './MiscParty.model'
import { PartyType } from './MiscParty.model'
import { AppService } from '../../AppServices/app.service';


@Component({

    selector: "CartPly",
    templateUrl: 'MiscParty.component.html',
    //styleUrls: ['./Miscpart.component.css'],
     //providers: [CommonService]

})
export class MiscParty {
    PID: number;
    msg: string
    btnText: string = "Save";
    private GetUrl: any;
    SelectedValue: any = 0;
    EditedData: MiscPartyModel[];
    PartyTypedata: PartyType[]
    model = new MiscPartyModel();
    constructor(
        
        private _AppService: AppService, private http:
            Http, private route: ActivatedRoute, private router: Router) {
        this.model.TYPE = this.SelectedValue.toString()
        this.getPartType();
    }
    ngOnInit(): void {
        this.GetUrl = this.route.queryParams
            .subscribe(params => {
                // Defaults to 0 if no query param provided.
                this.PID = + params['Id'] || 0;
            });
        if (this.PID != 0) {
            this.btnText = "Update"
            this.LoadMiscParty(this.PID);
        }


    }
    LoadMiscParty(PID): void {

        this._AppService.get(this._AppService.getProdUrl()+"/api/MiscPartyApi/GetMiscPartyById?PID=" + PID)
            .subscribe(res => {

                let Responsedata = JSON.stringify(res);
                this.EditedData = JSON.parse(Responsedata);
                this.SelectedValue = this.EditedData[0].TYPE.toString();
                console.log(this.EditedData)
                this.model = this.EditedData[0]
            },

            error => this.msg = <any>error);
    };


    //Get Party Type for Dropdown
    getPartType() {
        this.http.get(this._AppService.getProdUrl()+"/api/MiscPartyApi/GetpartyType")
            .subscribe(res => {
                let Responsedata = JSON.stringify(res.json());
                this.PartyTypedata = JSON.parse(Responsedata);
                console.log(this.PartyTypedata)
            })
    }
    // GetPartyType Id from  Dropdown
    GetPartyTypeId(id): void {

        this.model.TYPE = id;

    }
    onSubmit(valid) {

        console.log("Pid=" + this.PID)
        if (this.PID != 0) {
            this.http.put(this._AppService.getProdUrl()+"/api/MiscPartyApi/UpdateMiscParty", this.model)
                .subscribe(
                res => {
                    let Response = JSON.stringify(res);
                    let ResponseData = JSON.parse(Response);
                    if (ResponseData.status == 200) {

                        alert("Record updated Sucessfully");
                        this.router.navigate(['/MiscParty']);
                    }
                }
                );
        }
        else {
            if (valid)
                this.http.post(this._AppService.getProdUrl()+"/api/MiscPartyApi/InsertMiscParty", this.model)
                    .subscribe(
                    res => {
                        let Response = JSON.stringify(res);
                        let ResponseData = JSON.parse(Response);
                        if (ResponseData.status == 200) {
                            alert("Record Saved Sucessfully");
                            this.router.navigate(['/MiscParty']);
                        }
                    }
                    );


        };
    }







}