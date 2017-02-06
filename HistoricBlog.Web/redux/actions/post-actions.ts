import { Inject } from '@angular/core';
import { IPost } from './post-interface'
import { PostService } from '../../app/posts/post.service';
import { AppStore } from '../../app/app.module';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';

import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams } from '@angular/http';


export const ADD_POST = "ADD_POST";
export const EDIT_POST = "EDIT_POST";
export const GET_POST = "GET_POST";
export const GET_POSTS = "GET_POSTS";
export const SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
export const SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
export const SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
export const SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
export const SET_ERRORS = "SET_ERRORS";




export class PostActions {
    private _postUrl = 'http://localhost:58141/api/post';
    constructor( @Inject(Http) private _http: Http) { }

    //addPost(post: IPost, json) {

    //    return { type: ADD_POST, payload:post }
    //}

    addPost(post) {
        let body = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        console.log(body);
        const request = this._http.post(this._postUrl, body, options)
            .toPromise();

        request.then((post: Response) => AppStore.dispatch({ type: 'ADD_POST', payload: post.json() }))
            .catch((error: Response) => AppStore.dispatch({ type: 'SET_ERRORS', payload: error.json() }));

    }

    getAllPosts(post) {
        return { type: GET_POSTS, payload: post }
    }

    editPost(post: IPost) {
        return { type: EDIT_POST, payload: post }
    }

    setPostCategoryFilter(categories: string[]) {
        return { type: SET_POSTS_CATEGORY_FILTER, filterCategory: categories }
    }

    setPostTagFilter(tags: string[]) {
        return { type: SET_POSTS_TAG_FILTER, filterTag: tags }
    }

    setPostTitleFilter(title: string) {
        return { type: SET_POSTS_TITLE_FILTER, filterTitle: title }
    }

    setPostListPage(pageNumber: number) {
        return { type: SET_POSTS_LIST_PAGE, pageNumber: pageNumber }
    }

    setErrors(errors: string[]) {
        return { type: SET_ERRORS, payload: errors }
    }

    getPost(post: IPost) {
        return { type: GET_POST, payload: post }
    }
}
