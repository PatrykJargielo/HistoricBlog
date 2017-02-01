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
require("rxjs/add/operator/map");
require("rxjs/add/operator/do");
require("rxjs/add/operator/catch");
require("rxjs/add/operator/toPromise");
require("rxjs/Rx");
var PostService = (function () {
    function PostService(_http) {
        this._http = _http;
<<<<<<< HEAD
        this._productUrl = 'http://localhost:58141/api/post';
=======
        this._postUrl = 'http://localhost:58141/api/post/';
>>>>>>> Patryk_Jargieło
    }
    PostService.prototype.getPosts = function () {
        return this._http.get(this._postUrl).toPromise();
    };
    // getPost(id: number): Promise<IPost> {
    //     let params: URLSearchParams = new URLSearchParams();
    //     params.set('id', id.toString());
    //     return this._http.get(this._postUrl, { search: params }).toPromise();
    // }
    PostService.prototype.getPost = function (id) {
        var url = this._postUrl + "/" + id;
        return this._http.get(url)
            .toPromise()
            .then(function (response) { return response.json().data; })
            .catch(this.handleError);
    };
    PostService.prototype.getPostsFilteredPage = function (page, quantity, titleFilter) {
        var params = new http_1.URLSearchParams();
        params.set('page', page.toString());
        params.set('quantity', quantity.toString());
        if (titleFilter.length > 0)
            params.set('titleFilter', titleFilter);
        return this._http.get(this._productUrl, { search: params }).toPromise();
    };
    PostService.prototype.addPost = function (post) {
        var body = JSON.stringify(post);
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        console.log(body);
        return this._http.post(this._productUrl, body, options)
            .toPromise()
            .then(function (res) { return res.json() || {}; });
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
    //private extractData(res: Response) {
    //    let body = res.json();
    //    return body.data;
    //}
    PostService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error.json().error || 'Server error');
    };
    return PostService;
}());
PostService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], PostService);
exports.PostService = PostService;
//# sourceMappingURL=post.service.js.map