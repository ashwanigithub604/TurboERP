import { Component,OnInit} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { AppService } from '../../AppServices/app.service';

declare var require: any;
@Component({
    templateUrl: 'grid.component.html'
})

export class GridComponent implements OnInit {
    private GetUrl: any;
    show:boolean=false;
    constructor(private _AppService: AppService,private _route: ActivatedRoute,private router:Router) {
        this._route.url.subscribe((url:any) =>{this.GetUrl=url[0].path;});    
    };

   
    msg: string;
    resultList: any[];
    keys:any[];
    ngOnInit(): void {

        this.LoadGrid();
       
    }
    
   
    LoadGrid(): void {
       
        this._AppService.get("http://localhost:52148/"+this.GetUrl)
            .subscribe(result => {
                this.resultList = result;
                if(this.resultList.length!=0){
                    this.show=true;
                    this.keys= Object.keys(this.resultList[0])
                    
                }
             
                console.log(this.resultList);
            },

            error => this.msg = <any>error);
    };
    Delete(PID): void {
       
        this._AppService.delete("http://localhost:52148/api/"+this.GetUrl+"Api/Delete"+this.GetUrl+"?Pid="+PID)
            .subscribe(result => { 
                if(result!=""){
                    this.LoadGrid(); 
                }
            },

            error => this.msg = <any>error);
    };
    getHome(): void {
        this.router.navigate(['/Home']);
    };
    
   
}
