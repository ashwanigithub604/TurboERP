import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class AppService {
    constructor(private _http: Http) { }

    get(url: string): Observable<any> {
        return this._http.get(url)
            .map((response: Response) => <any>response.json())
            // .do(data => console.log("All: " + JSON.stringify(data)))
            .catch(this.handleError);
    }

    post(url: string, model): Observable<any> {
        return this._http.post(url, model)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    put(url: string, model): Observable<any> {
        return this._http.put(url, model)
            .map((response: Response) => <any>response.json())
            .catch(this.handleError);
    }

    delete(url: string): Observable<any> {
        return this._http.delete(url)
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
    getProdUrl(): string { 
        return "http://localhost:52148"; 
     }  

}