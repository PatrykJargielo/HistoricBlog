import { Component, NgZone } from '@angular/core';
import { AppStore } from '../app.module';
import { PostsState } from '../../redux/post-state';

@Component({
    selector: 'hb-error-display',
    template: `<div *ngIf='errorList.length > 0;'>
                    <ul *ngFor='let error of errorList'>
                        <li>{{error}}</li>
                    </ul>
               </div>`
})

export class ErrorDisplayComponent {
    errorList: string[];

    constructor(private zone: NgZone) {
        this.errorList = [];
        AppStore.subscribe(()=>this.errorListener());
    }

    errorListener():void {
        let stateModel = AppStore.getState() as PostsState;
        let errors = stateModel.errors;
        this.zone.run(() => {
             this.errorList = stateModel.errors;
        });
        
    }

 
    
}