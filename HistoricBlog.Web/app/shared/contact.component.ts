import { Component } from '@angular/core';

@Component({
    selector: 'contact',
    templateUrl: 'app/shared/contact.component.html'
})

export class ContactComponent {
    private projectName: string;
    constructor(){
        this.projectName="Historia Bartoszyc";
    }
}