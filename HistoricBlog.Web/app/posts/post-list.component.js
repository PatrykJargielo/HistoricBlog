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
var post_actions_1 = require("../../redux/actions/post-actions");
var post_service_1 = require("./post.service");
var app_module_1 = require("../app.module");
var PostListComponent = (function () {
    function PostListComponent(postService, _postActions, zone) {
        this._postActions = _postActions;
        this.zone = zone;
        this.listFilter = "";
        this.posts = [];
        this._postService = postService;
    }
    PostListComponent.prototype.getAllPosts = function () {
        var _this = this;
        return function (dispatch) {
            _this._postService.getPosts().then(function (posts) { return dispatch(_this._postActions.getAllPosts(JSON.parse(posts._body))); });
        };
    };
    PostListComponent.prototype.postListener = function () {
        var _this = this;
        var state = app_module_1.AppStore.getState();
        console.log('listener', this);
        this.zone.run(function () {
            _this.posts = state.posts;
        });
    };
    PostListComponent.prototype.ngOnInit = function () {
        var _this = this;
        app_module_1.AppStore.subscribe(function () {
            _this.postListener();
        });
        app_module_1.AppStore.dispatch(this.getAllPosts());
    };
    return PostListComponent;
}());
PostListComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/posts/post-list.component.html',
        styleUrls: ['app/posts/post-list.component.css']
    }),
    __param(0, core_1.Inject(post_service_1.PostService)),
    __metadata("design:paramtypes", [post_service_1.PostService, post_actions_1.PostActions, core_1.NgZone])
], PostListComponent);
exports.PostListComponent = PostListComponent;
//# sourceMappingURL=post-list.component.js.map