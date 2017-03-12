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
var app_module_1 = require("../app.module");
var ErrorDisplayComponent = (function () {
    function ErrorDisplayComponent(zone) {
        var _this = this;
        this.zone = zone;
        this.errorList = [];
        app_module_1.AppStore.subscribe(function () { return _this.errorListener(); });
    }
    ErrorDisplayComponent.prototype.errorListener = function () {
        var _this = this;
        var stateModel = app_module_1.AppStore.getState();
        var errors = stateModel.errors;
        this.zone.run(function () {
            _this.errorList = stateModel.errors;
        });
    };
    return ErrorDisplayComponent;
}());
ErrorDisplayComponent = __decorate([
    core_1.Component({
        selector: 'hb-error-display',
        template: "<div *ngIf='errorList !== undefined;'>\n                    <ul *ngFor='let error of errorList'>\n                        <li>{{error}}</li>\n                    </ul>\n               </div>"
    }),
    __metadata("design:paramtypes", [core_1.NgZone])
], ErrorDisplayComponent);
exports.ErrorDisplayComponent = ErrorDisplayComponent;
//# sourceMappingURL=error-display.component.js.map