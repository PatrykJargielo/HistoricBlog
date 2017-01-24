"use strict";
var post_actions_1 = require("../actions/post-actions");
var initialState = {
    posts: new Array()
};
function posts(state, action) {
    if (state === void 0) { state = initialState; }
    switch (action.type) {
        case post_actions_1.ADD_POST:
            return state;
        case post_actions_1.EDIT_POST:
            return state;
        case post_actions_1.GET_POSTS:
            return {
                posts: state.posts.concat(action.posts)
            };
        default:
            return state;
    }
}
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = posts;
//# sourceMappingURL=post-reducer.js.map