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
var postEditor_1 = require("./postEditor");
var PostEditor = (function () {
    function PostEditor(postService) {
        this.postService = postService;
        this.model = new postEditor_1.Post();
    }
    PostEditor.prototype.addPost = function () {
        this.model.Tags = this.tags.split(',');
        this.model.Categories.Name = this.categories.split(',');
        this.postService.addPost(this.model);
    };
    return PostEditor;
}());
PostEditor = __decorate([
    core_1.Component({
        selector: 'editor',
        templateUrl: 'app/posts/post-editor.component.html'
    }),
    __metadata("design:paramtypes", [post_service_1.PostService])
], PostEditor);
exports.PostEditor = PostEditor;
//# sourceMappingURL=post-editor.component.js.map