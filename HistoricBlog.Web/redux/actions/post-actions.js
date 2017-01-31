"use strict";
exports.ADD_POST = "ADD_POST";
exports.EDIT_POST = "EDIT_POST";
exports.GET_POSTS = "GET_POSTS";
exports.SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
exports.SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
exports.SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
exports.SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
exports.SET_P_LIST_PAGE = "SET_POSTS_LIST_PAGE";
var PostActions = (function () {
    function PostActions() {
    }
    PostActions.prototype.addPost = function (post) {
        return { type: exports.ADD_POST, payload: post };
    };
    PostActions.prototype.getAllPosts = function (post) {
        return { type: exports.GET_POSTS, payload: post };
    };
    PostActions.prototype.editPost = function (post) {
        return { type: exports.EDIT_POST, payload: post };
    };
    PostActions.prototype.setPostCategoryFilter = function (categories) {
        return { type: exports.SET_POSTS_CATEGORY_FILTER, filterCategory: categories };
    };
    PostActions.prototype.setPostTagFilter = function (tags) {
        return { type: exports.SET_POSTS_TAG_FILTER, filterTag: tags };
    };
    PostActions.prototype.setPostTitleFilter = function (title) {
        return { type: exports.SET_POSTS_TITLE_FILTER, filterTitle: title };
    };
    PostActions.prototype.setPostListPage = function (pageNumber) {
        return { type: exports.SET_POSTS_LIST_PAGE, pageNumber: pageNumber };
    };
    return PostActions;
}());
exports.PostActions = PostActions;
//# sourceMappingURL=post-actions.js.map