import { Inject } from '@angular/core';
import { IPost } from './post-interface'
import { PostService } from '../../app/posts/post.service';
import { AppStore } from '../../app/app.module';
import { HBlogState as PostsState } from '../../redux/hblog-state';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';

import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams } from '@angular/http';



export const ADD_OR_UPDATE_POST_REQUEST = "ADD_OR_UPDATE_POST_REQUEST";
export const ADD_OR_UPDATE_POST_SUCCESS = "ADD_OR_UPDATE_POST_SUCCESS";
export const ADD_OR_UPDATE_POST_ERROR = "ADD_OR_UPDATE_POST_ERROR";

export const GET_POST_REQUEST = "GET_POST_REQUEST";
export const GET_POST_SUCCESS = "GET_POST_SUCCESS";
export const GET_POST_ERROR = "GET_POST_ERROR";

export const GET_POSTS_REQUEST = "GET_POSTS_REQUEST";
export const GET_POSTS_SUCCESS = "GET_POSTS_SUCCESS";
export const GET_POSTS_ERROR = "GET_POSTS_ERROR";

export const SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
export const SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
export const SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
export const SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
export const SET_ERRORS = "SET_ERRORS";



//export const GET_POST = "GET_POST";
//export const GET_POSTS = "GET_POSTS";
//export const SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
//export const SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
//export const SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
//export const SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
//export const SET_ERRORS = "SET_ERRORS";




export class PostActions {
    id: number;
    private _postUrl = 'http://localhost:58141/api/post';
    constructor( @Inject(Http) private _http: Http) { }

    addPostRequest(post) {
        return { type: ADD_OR_UPDATE_POST_REQUEST, payload: post }
    }
    addPostSuccess(response) {
        return { type: ADD_OR_UPDATE_POST_SUCCESS, payload: response }
    }

    addPostError(error: string[]) {
        return { type: SET_ERRORS, payload: error }
    }

    getAllPostsRequest(request) {
        return { type: GET_POSTS_REQUEST, payload: request }
    }
    getAllPostsSuccess(posts) {
        return { type: GET_POSTS_SUCCESS, payload: posts }
    }
    getAllPostsError(post) {
        return { type: GET_POSTS_ERROR, payload: post }
    }

    getPostRequest(request) {
        return { type: GET_POST_REQUEST, payload: request }
    }
    getPostSuccess(response) {
        return { type: GET_POST_SUCCESS, payload: response }
    }
    getPostError(error: string[]) {
        return { type: SET_ERRORS, payload: error }
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

    addPost(post: IPost) {
        let body = JSON.stringify(post);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        const request = this._http.post(`${this._postUrl}/${post.Id}`, body, options)
            .toPromise();
        AppStore.dispatch({ type: ADD_OR_UPDATE_POST_REQUEST, payload: request });

        return request
            .then((post: Response) => AppStore.dispatch({ type: ADD_OR_UPDATE_POST_SUCCESS, payload: post.json()}))
            .catch((error: Response) => AppStore.dispatch({ type: SET_ERRORS, payload: error.json }));

    }

    getPost(id: number) {

        const request = this._http.get(`${this._postUrl}/${id}`).toPromise();
        AppStore.dispatch({ type: GET_POST_REQUEST, payload: request });

        return request
            .then((response: Response) => AppStore.dispatch({ type: GET_POST_SUCCESS, payload: response.json() }))
            .catch((error: Response) => AppStore.dispatch({ type: SET_ERRORS, payload: error.json() }));
    }

    getAllPosts(post) {
        return { type: GET_POSTS_REQUEST, payload: post }
    }

    getPostsFilteredPage() {
        let stateModel = AppStore.getState() as PostsState;
        let pageNumber: number = stateModel.pagination.pageNumber;
        let postsOnPage: number = stateModel.pagination.postsOnPage;
        let filterTitle: string = stateModel.filterTitle;

        let params: URLSearchParams = new URLSearchParams();
        params.set('page', pageNumber.toString());
        params.set('quantity', postsOnPage.toString());
        if (filterTitle.length > 0) params.set('titleFilter', filterTitle);


        let request = this._http.get(this._postUrl, { search: params }).toPromise();
        AppStore.dispatch({ type: GET_POSTS_REQUEST, payload: request });

        return request.then((posts: Response) => AppStore.dispatch({ type: GET_POSTS_SUCCESS, payload: posts.json() }))
            .catch((error: Response) => AppStore.dispatch({ type: SET_ERRORS, payload: error.json }));


    }
}



