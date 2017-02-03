import { Injectable } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams  } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Post } from './postEditor';
import { AppStore } from '../app.module';
import { HBlogState as PostsState } from '../../redux/hblog-state';
import { PostActions } from '../../redux/actions/post-actions';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';


@Injectable()

export class PostService {


    private _postUrl = 'http://localhost:58141/api/post';

    constructor(private _http: Http, private _postActions: PostActions) { }



    getPosts(): Promise<any> {//deprecated
        return this._http.get(this._postUrl).toPromise();
    }

    getPostsFilteredPage() {
        let stateModel = AppStore.getState() as PostsState;
        let pageNumber:number = stateModel.pagination.pageNumber;
        let postsOnPage: number = stateModel.pagination.postsOnPage;
        let filterTitle: string = stateModel.filterTitle;

        let params: URLSearchParams = new URLSearchParams();
        params.set('page', pageNumber.toString());
        params.set('quantity', postsOnPage.toString());
        if (filterTitle.length > 0) params.set('titleFilter', filterTitle);


        let promise = this._http.get(this._postUrl, { search: params }).toPromise()
            .then((posts: Response) => AppStore.dispatch(this._postActions.getAllPosts(posts.json())))
            .catch((error:Response) => this.setErrors(error));


    }

    addPost(post: Object): Promise<IPost> {
        
        let body = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(this._postUrl, body, options)
            .toPromise()
            .then((res: Response) => res.json() || {})
            .catch((error: Response) => this.setErrors(error));
        
    }

    updatePost(post: IPost): Promise<IPost> {

        let body = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(`${this._postUrl}/${post.id}`, body, options)
            .toPromise()
            .then((res: Response) => res.json() || {});

    }

    // getPost(id: number): Promise<IPost> {

    //     let params: URLSearchParams = new URLSearchParams();
    //     params.set('id', id.toString());

    //     return this._http.get(this._postUrl, { search: params }).toPromise();
    // }

    getPost(id: number): Promise<any> {
        const url = `${this._postUrl}/${id}`;
        return this._http.get(url).toPromise()
            .catch(this.handleError);
    }
    getPostt(id: number): Promise<Post> {
        const url = `${this._postUrl}/${id}`;
        return this._http.get(url).toPromise().then((response: Response )=> response.json().data)
            .catch(this.handleError);
    }

    private handleError(error: Response) {

        console.error(error.json());

        return Observable.throw(error.json().error || 'Server error');

    }

    private setErrors(error: Response): void {
        let stateModel = AppStore.getState() as PostsState;

        AppStore.dispatch((dispatch) => {
            dispatch(this._postActions.setErrors(error.json()));
        }); 
    }
}