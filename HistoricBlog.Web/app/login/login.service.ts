import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { ILogin } from "./ilogin";
import {ILoginService} from "./ilogin.service";




@Injectable()
export class LoginService  implements ILoginService{
    tokenProviderUrl: string;
    http: Http;

    constructor(http: Http) {
        this.http = http;
    }

    login(login: ILogin): Promise<Response> {
        let headers : Headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options: RequestOptions = new RequestOptions({ headers: headers });
        let body : string = this.getLoginBody(login, "password");
        return this.http.post(this.tokenProviderUrl,body,options).toPromise();
    }

    logout(): Promise<Response> { throw new Error("Not implemented"); }

    private  getLoginBody(login: ILogin, grantType: string): string {
        return "grant_type=" +
            grantType +
            "&username=" +
            login.userName +
            "&password=" +
            login.password;
    }
}