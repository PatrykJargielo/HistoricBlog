"use strict";
var Post = (function () {
    function Post(Title, ShortDescription, Content, Categories, Tags) {
        this.Title = Title;
        this.ShortDescription = ShortDescription;
        this.Content = Content;
        this.Categories = Categories;
        this.Tags = Tags;
    }
    return Post;
}());
exports.Post = Post;
//# sourceMappingURL=postEditor.js.map