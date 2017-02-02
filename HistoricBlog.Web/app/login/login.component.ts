import { Component } from '@angular/core';
import { ILogin } from "./login";
import {LoginService} from "./login.service";

@Component({
    templateUrl:'app/login/login.component.html'
})
export class LoginComponent {
    login: ILogin

    constructor(private loginService: LoginService) {
        
    }
}