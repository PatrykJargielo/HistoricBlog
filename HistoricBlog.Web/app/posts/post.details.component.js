"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var PostDetailsComponent = (function () {
    function PostDetailsComponent() {
    }
    return PostDetailsComponent;
}());
PostDetailsComponent = __decorate([
    core_1.Component({
        selector: 'hb-post-list',
        templateUrl: 'app/posts/post.details.component.html',
        styleUrls: ['app/posts/post-list.component.css']
    })
], PostDetailsComponent);
exports.PostDetailsComponent = PostDetailsComponent;
;
//# sourceMappingURL=post.details.component.js.map