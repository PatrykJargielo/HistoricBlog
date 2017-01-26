"use strict";
var post_actions_1 = require("../actions/post-actions");
var post_state_1 = require("../post-state");
var clone = require("clone");
function posts(state, action) {
    if (state === void 0) { state = new post_state_1.PostsState(); }
    switch (action.type) {
        case post_actions_1.ADD_POST:
            return state;
        case post_actions_1.EDIT_POST:
            return state;
        case post_actions_1.GET_POSTS:
            //let clone = Object.assign(new PostsState(), state);
            var d = clone(state);
            d.posts = action.posts;
            return d;
        default:
            return state;
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = posts;
//# sourceMappingURL=post-reducer.js.map