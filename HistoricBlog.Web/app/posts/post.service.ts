import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams  } from '@angular/http';
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

    getPostsFilteredPage(page: number, quantity: number, titleFilter: string): Promise<any> {

        let params: URLSearchParams = new URLSearchParams();
        params.set('page', page.toString());
        params.set('quantity', quantity.toString());
        if(titleFilter.length>0) params.set('titleFilter', titleFilter);

        return this._http.get(this._productUrl, { search: params }).toPromise();
    }

    addPost(post: Object): Promise<Post[]> {
        
        let body = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(this._productUrl, body, options)
            .toPromise()
            .then((res: Response) => res.json() || {});
        
    }

    uptadePost(post: Object): Promise<Post[]> {

        let body = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(`${this._productUrl}/${body["id"]}`, body, options)
            .toPromise()
            .then((res: Response) => res.json() || {});

    }

    //private extractData(res: Response) {
    //    let body = res.json();
    //    return body.data;
    //}


    private handleError(error: Response) {

        console.error(error);

        return Observable.throw(error.json().error || 'Server error');

    }
}