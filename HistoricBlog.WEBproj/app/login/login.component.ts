import { Component } from '@angular/core';
import { ILogin } from "./ilogin";
import { LoginService } from "./login.service";
import { CKEditorModule } from 'ng2-ckeditor';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal'

@Component({
    templateUrl:'app/login/login.component.html'
})
export class LoginComponent  {
    login: ILogin;
    //docs about modal https://github.com/dougludlow/ng2-bs3-modal
    modal: ModalComponent;


    constructor(private loginService: LoginService, private formBuilder: FormBuilder) {

    }

    close(): void {
        this.modal.close();
    }

    open(): void {
        this.modal.open();
    }
}