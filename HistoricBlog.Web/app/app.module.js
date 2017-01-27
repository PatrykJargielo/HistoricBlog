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
var app_component_1 = require("./app.component");
var posts_list_component_1 = require("./posts/posts-list.component");
var redux_1 = require("redux");
var post_reducer_1 = require("../redux/reducers/post-reducer");
var post_actions_1 = require("../redux/actions/post-actions");
var post_service_1 = require("./posts/post-service");
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
            http_1.HttpModule,
            http_1.JsonpModule,
            forms_1.FormsModule,
        ],
        declarations: [
            app_component_1.AppComponent,
            posts_list_component_1.PostListComponent
        ],
        providers: [
            post_actions_1.PostActions,
            post_service_1.PostService
        ],
        bootstrap: [app_component_1.AppComponent, posts_list_component_1.PostListComponent]
    }),
    __metadata("design:paramtypes", [])
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map