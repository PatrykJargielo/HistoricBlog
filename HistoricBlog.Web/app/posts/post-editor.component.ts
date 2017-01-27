import { Component } from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { IPost } from '../../redux/actions/post-interface';
import { Post } from './postEditor';

@Component({
    selector: 'editor',
    template: `
    <form>
    <div class="form-group">
    <ckeditor [(ngModel)]="model.Content" debounce="500" name="content">
      <p>Hello <strong>world</strong></p>
    </ckeditor>
    
    <input type="text" class="form-control" placeholder="Tytul" [(ngModel)]="model.Title" name="title">
    </div>
    <button (click)="addPost()">Dodaj post</button>
    </form>
<p>{{Post}}</p>

  `

})
export class PostEditor {
    errorMessage: string;
    Content;
    Title;
    postContent: string;
    model: Post;

    constructor(private postService: PostService) {
        this.Content;
        this.Title;
        this.model = new Post('','');
    }



    addPost() {
        this.postService.addPost(this.model);

        console.log(this.model);
    }
    //addPost(model) {
    //    if (!model) {
    //        return;
    //    }
    //    this.postService.addPost(model).subscribe(
    //        model => this.posts.push(model), error => this.errorMessage = <any>error);
    //    console.log(this.Content);


}

