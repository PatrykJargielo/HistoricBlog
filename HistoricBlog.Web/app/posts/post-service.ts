﻿import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()

export class PostService {


    private _productUrl = 'http://localhost:58141/api/post/';
    constructor(private _http: Http) { }

    getProducts(): Observable<IPost[]> {
        return this._http.get(this._productUrl)
            .map((response: Response) => <IPost[]>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }




}