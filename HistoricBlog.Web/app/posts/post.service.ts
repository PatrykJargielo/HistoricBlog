﻿import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule, RequestOptions, Headers  } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Post } from './postEditor';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';


@Injectable()

export class PostService {


    private _productUrl = 'http://localhost:58141/api/post';

    constructor(private _http: Http) { }



    getPosts(): Promise<any> {
        return this._http.get(this._productUrl).toPromise();
    }

    addPost(post): Promise<any> {
        let bodyString = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        return this._http.post(this._productUrl, post, options)
            .toPromise();
    }


    private handleError(error: Response) {

        console.error(error);

        return Observable.throw(error.json().error || 'Server error');

    }
}