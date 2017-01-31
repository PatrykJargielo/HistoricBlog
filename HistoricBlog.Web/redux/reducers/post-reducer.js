"use strict";
var post_actions_1 = require("../actions/post-actions");
var defaultState = {
    userName: 'guest',
    token: '',
    filterCategory: [],
    filterTitle: '',
    filterTag: [],
    posts: [],
    pagination: {
        pageNumber: 1,
        totalFilteredPostCount: 2,
        postsOnPage: 5,
    }
};
function post(state, action) {
    if (state === void 0) { state = defaultState; }
    var newState = state;
    switch (action.type) {
        case post_actions_1.SET_POSTS_LIST_PAGE:
            newState = Object.assign({}, state);
            newState.pagination.pageNumber = action.pageNumber;
            return newState;
        case post_actions_1.ADD_POST:
            newState = Object.assign({}, state);
            newState.posts.concat(action.payload.post);
            return state;
        case post_actions_1.EDIT_POST:
            newState = Object.assign({}, state);
            newState.posts.filter(function (post) { return post.Id != action.post.Id; });
            newState.posts.concat(action.payload.post);
            return state;
        case post_actions_1.GET_POSTS:
            newState = Object.assign({}, state);
            newState.pagination.totalFilteredPostCount = action.payload.totalFilteredPostCount,
                newState.posts = action.payload.posts;
            return newState;
        case post_actions_1.SET_POSTS_TITLE_FILTER:
            newState = Object.assign({}, state);
            newState.filterTitle = action.filterTitle;
            return newState;
        default:
            return newState;
    }
}
exports.post = post;
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = post;
//# sourceMappingURL=post-reducer.js.map