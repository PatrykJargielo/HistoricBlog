import { Component} from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { IPost } from '../../redux/actions/post-interface';
import { Post } from './postEditor';

@Component({
    selector: 'editor',
    templateUrl: 'app/posts/post-editor.component.html'

})
export class PostEditor {
    errorMessage: string;
    Content;
    Id;
    Title;
    model: Post;
    ShortDescription;

    constructor(private postService: PostService) {
        this.Content;
        this.Title;
        this.ShortDescription;
        this.model = new Post('', '', '');
    }



    addPost() {
        this.postService.addPost(this.model);

        console.log(this.model);
    }


}

