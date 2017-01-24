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
var post_service_1 = require("./post-service");
var app_module_1 = require("../app.module");
var PostListComponent = (function () {
    function PostListComponent(_productService, _postActions) {
        //let state = AppStore.getState();
        this._productService = _productService;
        this._postActions = _postActions;
    }
    ;
    PostListComponent.prototype.ngOnInit = function () {
        var _this = this;
        app_module_1.AppStore.subscribe(function () { return console.log(app_module_1.AppStore.getState()); });
        this._productService.getProducts()
            .subscribe(function (x) { return _this.posts = x; });
        app_module_1.AppStore.dispatch(this._postActions.getAllPosts(this.posts));
    };
    return PostListComponent;
}());
PostListComponent = __decorate([
    core_1.Component({
        selector: 'hb-posts-list',
        moduleId: module.id,
        templateUrl: 'post-list.component.html',
        styleUrls: ['post-list.component.css']
    }),
    __metadata("design:paramtypes", [post_service_1.PostService, post_actions_1.PostActions])
], PostListComponent);
exports.PostListComponent = PostListComponent;
//# sourceMappingURL=posts-list.component.js.map