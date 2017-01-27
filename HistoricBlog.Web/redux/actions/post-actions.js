"use strict";
exports.ADD_POST = "ADD_POST";
exports.EDIT_POST = "EDIT_POST";
exports.GET_POSTS = "GET_POSTS";
var PostActions = (function () {
    function PostActions() {
    }
    PostActions.prototype.addPost = function (post) {
        return { type: exports.ADD_POST, post: post };
    };
    PostActions.prototype.getAllPosts = function (post) {
        return { type: exports.GET_POSTS, post: post };
    };
    PostActions.prototype.editPost = function (post) {
        return { type: exports.EDIT_POST, post: post };
    };
    return PostActions;
}());
exports.PostActions = PostActions;
//# sourceMappingURL=post-actions.js.map