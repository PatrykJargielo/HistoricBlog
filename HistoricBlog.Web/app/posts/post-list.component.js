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
var post_actions_1 = require("../../redux/actions/post-actions");
var post_service_1 = require("./post.service");
var app_module_1 = require("../app.module");
var PostListComponent = (function () {
    function PostListComponent(postService, _postActions, zone) {
        this.postService = postService;
        this._postActions = _postActions;
        this.zone = zone;
        this.posts = [];
        this.postService = postService;
        this.stateModel = app_module_1.AppStore.getState();
        this.listFilter = '';
    }
    PostListComponent.prototype.ngOnInit = function () {
        var _this = this;
        app_module_1.AppStore.subscribe(function () {
            _this.postListener();
        });
        app_module_1.AppStore.dispatch(this.getAllPosts());
    };
    PostListComponent.prototype.postListener = function () {
        var _this = this;
        this.stateModel = app_module_1.AppStore.getState();
        this.zone.run(function () {
            _this.posts = _this.stateModel.posts;
        });
    };
    PostListComponent.prototype.getAllPosts = function () {
        var _this = this;
        return function (dispatch) {
            _this.postService.getPostsFilteredPage(_this.stateModel.pagination.pageNumber, _this.stateModel.pagination.postsOnPage, _this.stateModel.filterTitle).then(function (posts) { return dispatch(_this._postActions.getAllPosts(posts.json())); });
        };
    };
    PostListComponent.prototype.setTitleFilter = function (value) {
        var _this = this;
        app_module_1.AppStore.dispatch(function (dispatch) {
            dispatch(_this._postActions.setPostTitleFilter(value));
        });
        app_module_1.AppStore.dispatch(this.getAllPosts());
    };
    PostListComponent.prototype.getPostCount = function () {
        return this.stateModel.pagination.totalFilteredPostCount;
    };
    PostListComponent.prototype.getPostsOnPageCount = function () {
        return this.stateModel.pagination.postsOnPage;
    };
    PostListComponent.prototype.getCurrentPageNumber = function () {
        return this.stateModel.pagination.pageNumber;
    };
    PostListComponent.prototype.pageChanged = function (value) {
        var _this = this;
        app_module_1.AppStore.dispatch(function (dispatch) { dispatch(_this._postActions.setPostListPage(value)); });
        app_module_1.AppStore.dispatch(this.getAllPosts());
    };
    return PostListComponent;
}());
PostListComponent = __decorate([
    core_1.Component({
        selector: 'hb-posts-list',
        templateUrl: 'app/posts/post-list.component.html',
        styleUrls: ['app/posts/post-list.component.css']
    }),
    __metadata("design:paramtypes", [post_service_1.PostService, post_actions_1.PostActions, core_1.NgZone])
], PostListComponent);
exports.PostListComponent = PostListComponent;
//# sourceMappingURL=post-list.component.js.map