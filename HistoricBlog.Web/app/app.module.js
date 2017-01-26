"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var forms_1 = require("@angular/forms");
var http_1 = require("@angular/http");
var app_component_1 = require("./app.component");
var post_list_component_1 = require("./posts/post-list.component");
var redux_1 = require("redux");
var rootReducer_1 = require("../redux/reducers/rootReducer");
var post_actions_1 = require("../redux/actions/post-actions");
var post_filter_pipe_1 = require("./posts/post-filter.pipe");
require("redux-devtools-extension");
exports.AppStore = redux_1.createStore(rootReducer_1.rootReducer);
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
            http_1.JsonpModule
        ],
        declarations: [
            app_component_1.AppComponent,
            post_list_component_1.PostListComponent,
            post_filter_pipe_1.PostFilterPipe
        ],
        providers: [
            post_actions_1.PostActions
        ],
        bootstrap: [app_component_1.AppComponent, post_list_component_1.PostListComponent]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map