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
var forms_1 = require("@angular/forms");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var router_1 = require("@angular/router");
var app_component_1 = require("./app.component");
var post_list_component_1 = require("./posts/post-list.component");
var post_details_component_1 = require("./posts/post-details.component");
var post_guard_service_1 = require("./posts/post-guard.service");
var error_display_component_1 = require("./shared/error-display.component");
var redux_1 = require("redux");
var post_reducer_1 = require("../redux/reducers/post-reducer");
var post_actions_1 = require("../redux/actions/post-actions");
var post_service_1 = require("./posts/post.service");
var category_service_1 = require("./posts/category.service");
var post_editor_component_1 = require("./posts/post-editor.component");
var ng2_pagination_1 = require("ng2-pagination");
var ng2_ckeditor_1 = require("ng2-ckeditor");
var redux_thunk_1 = require("redux-thunk");
var createLogger = require("redux-logger");
var logger = createLogger();
var composeEnhancers = window['__REDUX_DEVTOOLS_EXTENSION_COMPOSE__'] || redux_1.compose;
exports.AppStore = redux_1.createStore(post_reducer_1.post, composeEnhancers(redux_1.applyMiddleware(redux_thunk_1.default, logger)));
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    core_1.NgModule({
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            http_1.JsonpModule,
            ng2_ckeditor_1.CKEditorModule,
            ng2_pagination_1.Ng2PaginationModule,
            router_1.RouterModule.forRoot([
                { path: '', component: post_list_component_1.PostListComponent },
                {
                    path: 'post/:id',
                    canActivate: [post_guard_service_1.PostDetailGuard],
                    component: post_details_component_1.PostDetailsComponent
                },
                { path: 'posts', redirectTo: '', pathMatch: 'full' },
                { path: '**', redirectTo: '', pathMatch: 'full' }
            ])
        ],
        declarations: [
            app_component_1.AppComponent,
            post_list_component_1.PostListComponent,
            error_display_component_1.ErrorDisplayComponent,
            post_editor_component_1.PostEditor,
            post_details_component_1.PostDetailsComponent
        ],
        providers: [
            post_actions_1.PostActions,
            post_service_1.PostService,
            category_service_1.CategoryService,
            post_guard_service_1.PostDetailGuard
        ],
        bootstrap: [app_component_1.AppComponent]
    }),
    __metadata("design:paramtypes", [])
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map