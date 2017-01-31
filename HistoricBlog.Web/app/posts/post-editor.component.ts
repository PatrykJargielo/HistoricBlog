import { Component, OnInit} from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { IPost } from '../../redux/actions/post-interface';
import { Post } from './postEditor';
import { Category } from './Category';

@Component({
    selector: 'editor',
    templateUrl: 'app/posts/post-editor.component.html'

})
export class PostEditor{
    model: Post;
    tags: string
    categories: string

    constructor(private postService: PostService, private categoryService: CategoryService) {
        this.model = new Post();
    }

    
    addPost() {
        this.model.Tags = this.tags.(' ');
        this.model.Categories = this.categories.split(' ');
        this.postService.addPost(this.model);

        console.log(this.model);
    }


}

