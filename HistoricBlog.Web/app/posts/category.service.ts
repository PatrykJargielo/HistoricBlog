import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Post } from './postEditor';
import { Category } from './Category';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';


@Injectable()

export class CategoryService {


    private _productUrl = 'http://localhost:58141/api/category';

    constructor(private _http: Http) { }



    getCategories(): Promise<any> {
        return this._http.get(this._productUrl).toPromise();
    }

    addCategory(category): Promise<string> {     
            let body = JSON.stringify(category);
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: headers });
            console.log(body);
            return this._http.post(this._productUrl, body, options)
                .toPromise()
                .then((res: Response) => res.json() || {});

        }

    private handleError(error: Response) {

        console.error(error);

        return Observable.throw(error.json().error || 'Server error');

    }
}