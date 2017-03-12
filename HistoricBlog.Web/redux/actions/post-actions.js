"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var __param = (this && this.__param) || function (paramIndex, decorator) {
    return function (target, key) { decorator(target, key, paramIndex); }
};
var core_1 = require("@angular/core");
var app_module_1 = require("../../app/app.module");
require("rxjs/add/operator/map");
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/toPromise");
require("rxjs/Rx");
var http_1 = require("@angular/http");
exports.ADD_OR_UPDATE_POST_REQUEST = "ADD_OR_UPDATE_POST_REQUEST";
exports.ADD_OR_UPDATE_POST_SUCCESS = "ADD_OR_UPDATE_POST_SUCCESS";
exports.ADD_OR_UPDATE_POST_ERROR = "ADD_OR_UPDATE_POST_ERROR";
exports.GET_POST_REQUEST = "GET_POST_REQUEST";
exports.GET_POST_SUCCESS = "GET_POST_SUCCESS";
exports.GET_POST_ERROR = "GET_POST_ERROR";
exports.GET_POSTS_REQUEST = "GET_POSTS_REQUEST";
exports.GET_POSTS_SUCCESS = "GET_POSTS_SUCCESS";
exports.GET_POSTS_ERROR = "GET_POSTS_ERROR";
exports.SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
exports.SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
exports.SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
exports.SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
exports.SET_ERRORS = "SET_ERRORS";
//export const GET_POST = "GET_POST";
//export const GET_POSTS = "GET_POSTS";
//export const SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
//export const SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
//export const SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
//export const SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
//export const SET_ERRORS = "SET_ERRORS";
var PostActions = (function () {
    function PostActions(_http) {
        this._http = _http;
        this._postUrl = 'http://localhost:58141/api/post';
    }
    PostActions.prototype.addPostRequest = function (post) {
        return { type: exports.ADD_OR_UPDATE_POST_REQUEST, payload: post };
    };
    PostActions.prototype.addPostSuccess = function (response) {
        return { type: exports.ADD_OR_UPDATE_POST_SUCCESS, payload: response };
    };
    PostActions.prototype.addPostError = function (error) {
        return { type: exports.SET_ERRORS, payload: error };
    };
    PostActions.prototype.getAllPostsRequest = function (request) {
        return { type: exports.GET_POSTS_REQUEST, payload: request };
    };
    PostActions.prototype.getAllPostsSuccess = function (posts) {
        return { type: exports.GET_POSTS_SUCCESS, payload: posts };
    };
    PostActions.prototype.getAllPostsError = function (post) {
        return { type: exports.GET_POSTS_ERROR, payload: post };
    };
    PostActions.prototype.getPostRequest = function (request) {
        return { type: exports.GET_POST_REQUEST, payload: request };
    };
    PostActions.prototype.getPostSuccess = function (response) {
        return { type: exports.GET_POST_SUCCESS, payload: response };
    };
    PostActions.prototype.getPostError = function (error) {
        return { type: exports.SET_ERRORS, payload: error };
    };
    PostActions.prototype.setPostCategoryFilter = function (categories) {
        return { type: exports.SET_POSTS_CATEGORY_FILTER, filterCategory: categories };
    };
    PostActions.prototype.setPostTagFilter = function (tags) {
        return { type: exports.SET_POSTS_TAG_FILTER, filterTag: tags };
    };
    PostActions.prototype.setPostTitleFilter = function (title) {
        return { type: exports.SET_POSTS_TITLE_FILTER, filterTitle: title };
    };
    PostActions.prototype.setPostListPage = function (pageNumber) {
        return { type: exports.SET_POSTS_LIST_PAGE, pageNumber: pageNumber };
    };
    PostActions.prototype.setErrors = function (errors) {
        return { type: exports.SET_ERRORS, payload: errors };
    };
    PostActions.prototype.addPost = function (post) {
        var body = JSON.stringify(post);
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        var request = this._http.post(this._postUrl + "/" + post.Id, body, options)
            .toPromise();
        app_module_1.AppStore.dispatch({ type: exports.ADD_OR_UPDATE_POST_REQUEST, payload: request });
        return request
            .then(function (post) { return app_module_1.AppStore.dispatch({ type: exports.ADD_OR_UPDATE_POST_SUCCESS, payload: post.json() }); })
            .catch(function (error) { return app_module_1.AppStore.dispatch({ type: exports.SET_ERRORS, payload: error.json }); });
    };
    PostActions.prototype.getPost = function (id) {
        var request = this._http.get(this._postUrl + "/" + id).toPromise();
        app_module_1.AppStore.dispatch({ type: exports.GET_POST_REQUEST, payload: request });
        return request
            .then(function (response) { return app_module_1.AppStore.dispatch({ type: exports.GET_POST_SUCCESS, payload: response.json() }); })
            .catch(function (error) { return app_module_1.AppStore.dispatch({ type: exports.SET_ERRORS, payload: error.json() }); });
    };
    PostActions.prototype.getAllPosts = function (post) {
        return { type: exports.GET_POSTS_REQUEST, payload: post };
    };
    PostActions.prototype.getPostsFilteredPage = function () {
        var stateModel = app_module_1.AppStore.getState();
        var pageNumber = stateModel.pagination.pageNumber;
        var postsOnPage = stateModel.pagination.postsOnPage;
        var filterTitle = stateModel.filterTitle;
        var params = new http_1.URLSearchParams();
        params.set('page', pageNumber.toString());
        params.set('quantity', postsOnPage.toString());
        if (filterTitle.length > 0)
            params.set('titleFilter', filterTitle);
        var request = this._http.get(this._postUrl, { search: params }).toPromise();
        app_module_1.AppStore.dispatch({ type: exports.GET_POSTS_REQUEST, payload: request });
        return request.then(function (posts) { return app_module_1.AppStore.dispatch({ type: exports.GET_POSTS_SUCCESS, payload: posts.json() }); })
            .catch(function (error) { return app_module_1.AppStore.dispatch({ type: exports.SET_ERRORS, payload: error.json }); });
    };
    return PostActions;
}());
PostActions = __decorate([
    __param(0, core_1.Inject(http_1.Http)),
    __metadata("design:paramtypes", [http_1.Http])
], PostActions);
exports.PostActions = PostActions;
//# sourceMappingURL=post-actions.js.map