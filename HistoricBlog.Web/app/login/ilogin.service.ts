import { ILogin } from "./ilogin";
import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams } from '@angular/http';

export interface ILoginService {
    tokenProviderUrl: string;
    http : Http;
    login(login: ILogin): Promise<Response>;
    logout(): Promise<Response>;
}