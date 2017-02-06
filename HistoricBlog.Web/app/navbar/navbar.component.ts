import { Component } from '@angular/core';

@Component({
    selector: 'navbar',
    templateUrl: 'app/navbar/navbar.component.html'
})

export class NavbarComponent {
    private projectName: string;
    constructor(){
        this.projectName="Historia Bartoszyc";
    }


}