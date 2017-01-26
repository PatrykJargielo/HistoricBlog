"use strict";
var post_actions_1 = require("../actions/post-actions");
var post_state_1 = require("../post-state");
var defaultState = new post_state_1.PostsState();
function posts(state, action) {
    if (state === void 0) { state = defaultState; }
    switch (action.type) {
        case post_actions_1.ADD_POST:
            return state;
        case post_actions_1.EDIT_POST:
            return state;
        case post_actions_1.GET_POSTS:
            var newState = Object.assign(new post_state_1.PostsState(), state);
            newState.posts = action.posts;
            return newState.posts;
        default:
            return state;
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = posts;
//# sourceMappingURL=post-reducer.js.map