﻿import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';


@Injectable()

export class PostService {


    private _postUrl = '/api/post/';
    constructor(private _http: Http) { }

<<<<<<< HEAD
        getPosts(): Promise<any> {
            return this._http.get(this._productUrl).toPromise();
            
=======
    getPosts(): Observable<IPost[]> {
        return this._http.get(this._postUrl)
            .map((response: Response) => <IPost[]>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
>>>>>>> origin/posts_-_searchbar
    }
    getPost(id: number): Observable<IPost> {
        return this.getPosts()
            .map((posts: IPost[]) => posts.find(p => p.id === id));
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
}