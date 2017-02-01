import { Component, OnInit} from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { Post } from './postEditor';
import { Category } from './Category';

@Component({
    selector: 'editor',
    templateUrl: 'app/posts/post-editor.component.html'

})
export class PostEditor{
    model: Post;
    tags: string;
    categories: string;

    constructor(private postService: PostService) {
        this.model = new Post();
    }

    
    addPost() {
        this.model.Tags = this.tags.split(',');
        this.model.Categories = this.categories.split(',');
        this.postService.addPost(this.model);

        console.log(this.model);

        
    }


}

