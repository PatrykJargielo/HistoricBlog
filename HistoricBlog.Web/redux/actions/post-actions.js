"use strict";
exports.ADD_POST = "ADD_POST";
exports.EDIT_POST = "EDIT_POST";
exports.GET_POSTS = "GET_POSTS";
var PostActions = (function () {
    function PostActions() {
    }
    //addPost(post: IPost[]) {
    //    return {type: ADD_POST, post }
    //}
    PostActions.prototype.getAllPosts = function (post) {
        return { type: exports.GET_POSTS, posts: post };
    };
    return PostActions;
}());
exports.PostActions = PostActions;
//# sourceMappingURL=post-actions.js.map