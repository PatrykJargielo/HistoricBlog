import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
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


    private handleError(error: Response) {

        console.error(error);

        return Observable.throw(error.json().error || 'Server error');

    }
}