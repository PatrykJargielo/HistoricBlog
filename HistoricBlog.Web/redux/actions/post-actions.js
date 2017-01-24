"use strict";
exports.ADD_POST = "ADD_POST";
exports.EDIT_POST = "EDIT_POST";
exports.GET_POSTS = "GET_POSTS";
var PostActions = (function () {
    function PostActions() {
    }
    PostActions.prototype.addPost = function (post) {
        return { ADD_POST: exports.ADD_POST, post: post };
    };
    PostActions.prototype.getAllPosts = function (posts) {
        return { type: exports.GET_POSTS, posts: posts };
    };
    PostActions.prototype.editPost = function (post) {
        return { ADD_POST: exports.ADD_POST, post: post };
    };
    return PostActions;
}());
exports.PostActions = PostActions;
//# sourceMappingURL=post-actions.js.map