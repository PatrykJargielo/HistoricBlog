"use strict";
var post_actions_1 = require("../actions/post-actions");
var generic_post_1 = require("../actions/generic-post");
var hblog_state_1 = require("../hblog-state");
//let defaultState = {
//    userName: 'guest',
//    token: '',
//    filterCategory: [],
//    filterTitle: '',
//    filterTag: [],
//    posts: [],
//    pagination: {
//        pageNumber: 1,
//        totalFilteredPostCount: 2,
//        postsOnPage: 5,
//    },
//    errors: []
//}
var defaultState = new hblog_state_1.HBlogState();
function post(state, action) {
    if (state === void 0) { state = defaultState; }
    var newState = state;
    switch (action.type) {
        case post_actions_1.SET_POSTS_LIST_PAGE:
            newState = Object.assign({}, state);
            newState.pagination.pageNumber = action.pageNumber;
            newState.errors = [];
            return newState;
        case post_actions_1.ADD_OR_UPDATE_POST_REQUEST:
            newState = Object.assign({}, state);
            newState.post.promise = action.payload;
            newState.post.status = generic_post_1.STATUS_STARTED;
            return newState;
        case post_actions_1.ADD_OR_UPDATE_POST_SUCCESS:
            newState = Object.assign({}, state);
            newState.post.data = action.payload.post;
            //newState.posts.status = STATUS_SUCCEEDED;
            return newState;
        case post_actions_1.ADD_OR_UPDATE_POST_ERROR:
            newState = Object.assign({}, state);
            newState.post.status = generic_post_1.STATUS_FAILED;
            newState.post.errors.error = [];
            return newState;
        case post_actions_1.GET_POSTS_REQUEST:
            newState = Object.assign({}, state);
            newState.posts.promise = action.payload;
            newState.posts.status = generic_post_1.STATUS_STARTED;
            return newState;
        case post_actions_1.GET_POSTS_SUCCESS:
            newState = Object.assign({}, state);
            newState.pagination.totalFilteredPostCount = action.payload.totalFilteredPostCount;
            newState.posts.data = action.payload.posts;
            return newState;
        case post_actions_1.GET_POSTS_ERROR:
            newState = Object.assign({}, state);
            newState.posts.status = generic_post_1.STATUS_FAILED;
            newState.errors = [];
            return newState;
        case post_actions_1.SET_POSTS_TITLE_FILTER:
            newState = Object.assign({}, state);
            newState.filterTitle = action.filterTitle;
            newState.errors = [];
            return newState;
        case post_actions_1.SET_ERRORS:
            ;
            newState = Object.assign({}, state);
            newState.posts.status = generic_post_1.STATUS_FAILED;
            newState.errors = action.payload;
            return newState;
        case post_actions_1.GET_POST_REQUEST:
            newState = Object.assign({}, state);
            newState.post.promise = action.payload;
            newState.post.status = generic_post_1.STATUS_STARTED;
            return newState;
        case post_actions_1.GET_POST_SUCCESS:
            newState = Object.assign({}, state);
            newState.post.data = action.payload;
            return newState;
        case post_actions_1.GET_POST_ERROR:
            newState = Object.assign({}, state);
            newState.post.status = generic_post_1.STATUS_FAILED;
            newState.errors = [];
            return newState;
        default:
            return newState;
    }
}
exports.post = post;
Object.defineProperty(exports, "__esModule", { value: true });
exports.default = post;
//# sourceMappingURL=post-reducer.js.map