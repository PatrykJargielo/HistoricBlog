"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var post_list_component_1 = require("./post-list.component");
var post_details_component_1 = require("./post-details.component");
var post_guard_service_1 = require("./post-guard.service");
var post_filter_pipe_1 = require("./post-filter.pipe");
var post_service_1 = require("./post.service");
var ProductModule = (function () {
    function ProductModule() {
    }
    return ProductModule;
}());
ProductModule = __decorate([
    core_1.NgModule({
        imports: [
            router_1.RouterModule.forChild([
                { path: 'products', component: post_list_component_1.PostListComponent },
                { path: 'product/:id',
                    canActivate: [post_guard_service_1.PostDetailGuard],
                    component: post_details_component_1.PostDetailsComponent
                }
            ])
        ],
        declarations: [
            post_list_component_1.PostListComponent,
            post_details_component_1.PostDetailsComponent,
            post_filter_pipe_1.PostFilterPipe
        ],
        providers: [
            post_service_1.PostService,
            post_guard_service_1.PostDetailGuard
        ]
    })
], ProductModule);
exports.ProductModule = ProductModule;
//# sourceMappingURL=post.module.js.map