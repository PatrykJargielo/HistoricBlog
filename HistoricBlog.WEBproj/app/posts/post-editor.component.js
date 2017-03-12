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
var post_service_1 = require("./post.service");
var app_module_1 = require("../app.module");
var post_actions_1 = require("../../redux/actions/post-actions");
var router_1 = require("@angular/router");
var forms_1 = require("@angular/forms");
var PostEditor = (function () {
    function PostEditor(postService, fb, route, _postActions, _router, zone, _postService) {
        this.postService = postService;
        this.fb = fb;
        this.route = route;
        this._postActions = _postActions;
        this._router = _router;
        this.zone = zone;
        this._postService = _postService;
        this.formErrors = {
            'Title': '',
            'ShortDescription': ''
        };
        this.validationMessages = {
            'Title': {
                'required': 'Tytuł jest wymagany',
                'minlength': 'Tytuł musi sie składać z co najmniej 10 znaków',
                'maxlength': 'Tytuł może mieć maksymalnie 50 znaków.'
            },
            'ShortDescription': {
                'required': 'Krótki opis jest wymagany',
                'minlength': 'Krótki opis musi sie składać z co najmniej 10 znaków',
                'maxlength': 'Krótki opis może mieć maksymalnie 500 znaków.'
            }
        };
        this.stateModel = app_module_1.AppStore.getState();
    }
    PostEditor.prototype.addPost = function () {
        this.post = this.postForm.value;
        this.model.Content = this.post.Content;
        this.model.Title = this.post.Title;
        this.model.ShortDescription = this.post.ShortDescription;
        this._postActions.addPost(this.model);
    };
    PostEditor.prototype.ngOnInit = function () {
        var _this = this;
        window['CKEDITOR']['replace']('editor1');
        app_module_1.AppStore.subscribe(function () { _this.postListener(); });
        this.sub = this.route.params.subscribe(function (params) {
            var id = +params['id'];
            //this.model = this.stateModel.post;
            console.log(id, "idCheck");
            if (typeof params['id'] === 'undefined') {
                _this.model = { Id: 0, Title: "", ShortDescription: "", Categories: [], Tags: [], Content: "" };
                console.log(_this.model, "Test");
            }
            else {
                var idFromRoute = +_this.route.snapshot.params['id'];
                _this._postActions.getPost(idFromRoute);
                _this.model = _this.stateModel.post.data;
                console.log(_this.model, "Test2");
            }
        });
        //TODO dispatch na getPost     
        this.buildForm();
        console.log(this.model, 'model');
    };
    PostEditor.prototype.postListener = function () {
        var _this = this;
        this.stateModel = app_module_1.AppStore.getState();
        this.zone.run(function () {
            _this.model = _this.stateModel.post.data;
            console.log(_this.model, 'dd2');
        });
    };
    //getPost(id: number) {
    //    let idFromRoute = + this.route.snapshot.params['id'];
    //    this._postActions.getPost(idFromRoute);
    //    console.log(this._postActions.getPost(idFromRoute), 'actionrIdRoute');
    //}
    PostEditor.prototype.buildForm = function () {
        var _this = this;
        this.postForm = this.fb.group({
            'Content': [this.model.Content],
            'Title': [
                this.model.Title, [
                    forms_1.Validators.required,
                    forms_1.Validators.minLength(10),
                    forms_1.Validators.maxLength(50)
                ]
            ],
            'ShortDescription': [
                this.model.ShortDescription, [
                    forms_1.Validators.required,
                    forms_1.Validators.minLength(10),
                    forms_1.Validators.maxLength(500)
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
    PostEditor.prototype.onBack = function () {
        this._router.navigate(['']);
    };
    PostEditor.prototype.ngOnDestroy = function () {
        this.sub.unsubscribe();
    };
    return PostEditor;
}());
PostEditor = __decorate([
    core_1.Component({
        templateUrl: 'app/posts/post-editor.component.html'
    }),
    __param(1, core_1.Inject(forms_1.FormBuilder)),
    __metadata("design:paramtypes", [post_service_1.PostService,
        forms_1.FormBuilder,
        router_1.ActivatedRoute,
        post_actions_1.PostActions,
        router_1.Router,
        core_1.NgZone,
        post_service_1.PostService])
], PostEditor);
exports.PostEditor = PostEditor;
//# sourceMappingURL=post-editor.component.js.map