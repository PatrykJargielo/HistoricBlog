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
var forms_1 = require("@angular/forms");
var PostEditor = (function () {
    function PostEditor(postService, fb) {
        this.postService = postService;
        this.fb = fb;
        this.formErrors = {
            'Title': '',
            'ShortDescription': '',
            'categories': '',
            'tags': ''
        };
        this.validationMessages = {
            'Title': {
                'required': 'Tytuł jest wymagany',
                'minlength': 'Tytuł musi sie składać z conajmniej 5 znaków',
                'maxlength': 'Tytul może mieć maksymalnie 50 znaków.'
            },
            'ShortDescription': {
                'required': 'Krótki opis jest wymagany',
                'minlength': 'Krótki opis musi sie składać z conajmniej 5 znaków',
                'maxlength': 'Krótki opis może mieć maksymalnie 50 znaków.'
            },
            'categories': {
                'required': 'Kategoria jest wymagany',
                'minlength': 'Kategoria musi sie składać z conajmniej 5 znaków',
                'maxlength': 'Kategoria może mieć maksymalnie 50 znaków.'
            },
            'tags': {
                'required': 'Tag jest wymagany',
                'minlength': 'Tag musi sie składać z conajmniej 5 znaków',
                'maxlength': 'Tag może mieć maksymalnie 50 znaków.'
            }
        };
    }
    PostEditor.prototype.addPost = function () {
        this.tagAndCategorySplit = this.postForm.value;
        this.model = this.tagAndCategorySplit;
        this.model.Categories = this.tagAndCategorySplit.categories.split(',');
        this.model.Tags = this.tagAndCategorySplit.tags.split(',');
        console.log(this.model);
        this.postService.addPost(this.model);
        console.log(this.model);
    };
    PostEditor.prototype.ngOnInit = function () {
        this.model = new postEditor_1.Post();
        this.buildForm();
    };
    PostEditor.prototype.buildForm = function () {
        var _this = this;
        this.postForm = this.fb.group({
            'Content': [this.model.Content],
            'Title': [
                this.model.Title, [
                    forms_1.Validators.required,
                    forms_1.Validators.minLength(4),
                    forms_1.Validators.maxLength(24)
                ]
            ],
            'ShortDescription': [
                this.model.ShortDescription, [
                    forms_1.Validators.required,
                    forms_1.Validators.minLength(4),
                    forms_1.Validators.maxLength(24)
                ]
            ],
            'categories': [
                this.categories, [
                    forms_1.Validators.required,
                    forms_1.Validators.minLength(2),
                    forms_1.Validators.maxLength(24)
                ]
            ],
            'tags': [
                this.tags, [
                    forms_1.Validators.required,
                    forms_1.Validators.minLength(3),
                    forms_1.Validators.maxLength(24)
                ]
            ]
        });
        this.postForm.valueChanges.subscribe(function (data) { return _this.onValueChanged(data); });
        this.onValueChanged();
    };
    PostEditor.prototype.onValueChanged = function (data) {
        if (!this.postForm) {
            return;
        }
        var form = this.postForm;
        for (var field in this.formErrors) {
            this.formErrors[field] = '';
            var control = form.get(field);
            if (control && control.dirty && !control.valid) {
                var messages = this.validationMessages[field];
                for (var key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                }
            }
        }
    };
    return PostEditor;
}());
PostEditor = __decorate([
    core_1.Component({
        selector: 'editor',
        templateUrl: 'app/posts/post-editor.component.html',
    }),
    __metadata("design:paramtypes", [post_service_1.PostService, forms_1.FormBuilder])
], PostEditor);
exports.PostEditor = PostEditor;
//# sourceMappingURL=post-editor.component.js.map