import { NgModule } from '@angular/core';
import { LoginComponent } from "./login.component";
import {LoginService} from "./login.service";

@NgModule({
    declarations: [
        LoginComponent
    ],
    imports: [],
    providers: [
        LoginService
    ]
    
})
export class LoginModule {
    
}