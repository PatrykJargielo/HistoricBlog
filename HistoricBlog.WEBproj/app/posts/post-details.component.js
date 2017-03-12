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
var router_1 = require("@angular/router");
var PostDetailsComponent = (function () {
    function PostDetailsComponent(_route, _router, _postService, route, _postActions, zone) {
        this._route = _route;
        this._router = _router;
        this._postService = _postService;
        this.route = route;
        this._postActions = _postActions;
        this.zone = zone;
        this.pageTitle = 'Post Detail';
        this.stateModel = app_module_1.AppStore.getState();
    }
    PostDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.stateModel = app_module_1.AppStore.getState();
        app_module_1.AppStore.subscribe(function () { _this.postListnener(); });
        this.sub = this._route.params.subscribe(function (params) {
            var id = +params['id'];
            app_module_1.AppStore.dispatch(_this.getPost(id));
        });
    };
    PostDetailsComponent.prototype.postListnener = function () {
        var _this = this;
        this.stateModel = app_module_1.AppStore.getState();
        this.post = this.stateModel.post.data;
        this.zone.run(function () {
            _this.post = _this.stateModel.post.data;
        });
    };
    PostDetailsComponent.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    PostDetailsComponent.prototype.getPost = function (id) {
        var _this = this;
        //// this._postService.getPost(id).subscribe(
        ////     post => this.post = id,
        ////     error => this.errorMessage = <any>error);
        var idFromRoute = +this.route.snapshot.params['id'];
        //this._postService.getPost(idFromRoute);
        //    .subscribe(post => this.post = post/*);*/
        return function (dispatch) {
            _this._postActions.getPost(idFromRoute);
        };
    };
    PostDetailsComponent.prototype.onBack = function () {
        this._router.navigate(['']);
    };
    PostDetailsComponent.prototype.onRatingClicked = function (message) {
        this.pageTitle = 'Post Detail: ' + message;
    };
    return PostDetailsComponent;
}());
PostDetailsComponent = __decorate([
    core_1.Component({
        templateUrl: 'app/posts/post-details.component.html'
    }),
    __metadata("design:paramtypes", [router_1.ActivatedRoute,
        router_1.Router,
        post_service_1.PostService,
        router_1.ActivatedRoute,
        post_actions_1.PostActions,
        core_1.NgZone])
], PostDetailsComponent);
exports.PostDetailsComponent = PostDetailsComponent;
;
//# sourceMappingURL=post-details.component.js.map