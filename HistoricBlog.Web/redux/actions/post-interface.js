"use strict";
var Post = (function () {
    function Post(id, title, shortDescription, content, categories, tags) {
        this.id = id;
        this.title = title;
        this.shortDescription = shortDescription;
        this.content = content;
        this.categories = categories;
        this.tags = tags;
    }
    return Post;
}());
exports.Post = Post;
//# sourceMappingURL=post-interface.js.map