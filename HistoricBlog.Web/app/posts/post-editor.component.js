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
        this.Content;
        this.Title;
        this.ShortDescription;
        this.model = new postEditor_1.Post('', '', '');
    }
    PostEditor.prototype.addPost = function () {
        this.postService.addPost(this.model);
        console.log(this.model);
    };
    return PostEditor;
}());
PostEditor = __decorate([
    core_1.Component({
        selector: 'editor',
        template: "\n    <form>\n    <div class=\"form-group\">\n    <ckeditor [(ngModel)]=\"model.Content\" debounce=\"500\" name=\"content\">\n      <p>Hello <strong>world</strong></p>\n    </ckeditor>\n    \n    <input type=\"text\" class=\"form-control\" placeholder=\"Tytul\" [(ngModel)]=\"model.Title\" name=\"title\">\n    <input type=\"text\" class=\"form-control\" placeholder=\"Short\" [(ngModel)]=\"model.ShortDescription\" name=\"ShortDescription\">\n    </div>\n    <button (click)=\"addPost()\">Dodaj post</button>\n    </form>\n\n\n  "
    }),
    __metadata("design:paramtypes", [post_service_1.PostService])
], PostEditor);
exports.PostEditor = PostEditor;
//# sourceMappingURL=post-editor.component.js.map