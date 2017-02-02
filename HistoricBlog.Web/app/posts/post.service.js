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
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
var app_module_1 = require("../app.module");
var post_actions_1 = require("../../redux/actions/post-actions");
require("rxjs/add/operator/map");
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/toPromise");
var PostService = (function () {
    function PostService(_http, _postActions) {
        this._http = _http;
        this._postActions = _postActions;
        this._productUrl = 'http://localhost:58141/api/post';
    }
    PostService.prototype.getPosts = function () {
        return this._http.get(this._productUrl).toPromise();
    };
    PostService.prototype.getPostsFilteredPage = function () {
        var _this = this;
        var stateModel = app_module_1.AppStore.getState();
        var pageNumber = stateModel.pagination.pageNumber;
        var postsOnPage = stateModel.pagination.postsOnPage;
        var filterTitle = stateModel.filterTitle;
        var params = new http_1.URLSearchParams();
        params.set('page', pageNumber.toString());
        params.set('quantity', postsOnPage.toString());
        if (filterTitle.length > 0)
            params.set('titleFilter', filterTitle);
        var promise = this._http.get(this._productUrl, { search: params }).toPromise()
            .then(function (posts) { return app_module_1.AppStore.dispatch(_this._postActions.getAllPosts(posts.json())); })
            .catch(function (error) { return _this.setErrors(error); });
    };
    PostService.prototype.addPost = function (post) {
        var _this = this;
        var body = JSON.stringify(post);
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(this._productUrl, body, options)
            .toPromise()
            .then(function (res) { return res.json() || {}; })
            .catch(function (error) { return _this.handleError(error); });
    };
    PostService.prototype.uptadePost = function (post) {
        var body = JSON.stringify(post);
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(this._productUrl + "/" + body["id"], body, options)
            .toPromise()
            .then(function (res) { return res.json() || {}; });
    };
    PostService.prototype.handleError = function (error) {
        console.error(error.json());
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    PostService.prototype.setErrors = function (error) {
        var _this = this;
        var stateModel = app_module_1.AppStore.getState();
        app_module_1.AppStore.dispatch(function (dispatch) {
            dispatch(_this._postActions.setErrors(error.json()));
        });
    };
    return PostService;
}());
PostService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, post_actions_1.PostActions])
], PostService);
exports.PostService = PostService;
//# sourceMappingURL=post.service.js.map