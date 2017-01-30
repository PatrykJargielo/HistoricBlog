"use strict";
var post_actions_1 = require("../actions/post-actions");
//import { PostsState } from '../post-state'
var defaultState = {
    page: 1,
    posts: []
};
function post(state, action) {
    if (state === void 0) { state = defaultState; }
    switch (action.type) {
        case post_actions_1.ADD_POST:
            return state;
        case post_actions_1.EDIT_POST:
            return state;
        case post_actions_1.GET_POSTS:
            return Object.assign({}, state, {
                page: 10,
                posts: action.post
            });
        default:
            return state;
    }
}
exports.post = post;
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = post;
//# sourceMappingURL=post-reducer.js.map