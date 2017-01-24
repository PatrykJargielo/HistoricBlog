"use strict";
var redux_1 = require("redux");
var post_reducer_1 = require("./post-reducer");
exports.rootReducer = redux_1.combineReducers({
    posts: post_reducer_1.default
});
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = exports.rootReducer;
//# sourceMappingURL=rootReducer.js.map