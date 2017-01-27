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
var post_service_1 = require("./post.service");
var PostListComponent = (function () {
    function PostListComponent(_postService) {
        this._postService = _postService;
    }
    // constructor( @Inject(PostService) postService: PostService, private _postActions: PostActions) {
    //     this._postService = postService;
    // }
    PostListComponent.prototype.ngOnInit = function () {
        // this._postService.getProducts()
        //     .subscribe(x => this.posts = x);
        // console.log(this.posts);
        // AppStore.dispatch(this._postActions.getAllPosts(this.posts));
        // console.log(AppStore.getState());
    };
    return PostListComponent;
}());
PostListComponent = __decorate([
    core_1.Component({
        selector: 'hb-posts-list',
        templateUrl: 'app/posts/post-list.component.html',
        styleUrls: ['app/posts/post-list.component.css']
    }),
    __metadata("design:paramtypes", [post_service_1.PostService])
], PostListComponent);
exports.PostListComponent = PostListComponent;
//# sourceMappingURL=post-list.component.js.map