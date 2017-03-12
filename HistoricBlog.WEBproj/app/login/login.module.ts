import { NgModule } from '@angular/core';
import { LoginComponent } from "./login.component";
import { LoginService } from "./login.service";
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { CKEditorModule } from 'ng2-ckeditor';

@NgModule({
    imports: [ 
        BrowserModule,
        HttpModule,
        Ng2Bs3ModalModule,
        CKEditorModule
    ],
    declarations: [
        LoginComponent
    ],
    providers: [
        LoginService
    ]
    
})
export class LoginModule {
    
}