import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';


@Injectable()

export class PostService {


    private _postUrl = 'http://localhost:58141/api/post/';

    constructor(private _http: Http) { }



    getPosts(): Promise<any> {
        return this._http.get(this._postUrl).toPromise();
    }

    // getPost(id: number): Promise<IPost> {

    //     let params: URLSearchParams = new URLSearchParams();
    //     params.set('id', id.toString());

    //     return this._http.get(this._postUrl, { search: params }).toPromise();
    // }

    getPost(id: number): Promise<any> {
        const url = `${this._postUrl}/${id}`;
        return this._http.get(url)
            .toPromise()
            .then(response => response.json().data as IPost)
            .catch(this.handleError);
    }

    private handleError(error: Response) {

        console.error(error);

        return Observable.throw(error.json().error || 'Server error');

    }
}