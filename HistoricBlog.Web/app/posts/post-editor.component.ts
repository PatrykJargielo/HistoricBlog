import { Component} from '@angular/core';
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
    <input type="text" class="form-control" placeholder="Short" [(ngModel)]="model.ShortDescription" name="ShortDescription">
    </div>
    <button (click)="addPost()">Dodaj post</button>
    </form>


  `

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
    //addPost(model) {
    //    if (!model) {
    //        return;
    //    }
    //    this.postService.addPost(model).subscribe(
    //        model => this.posts.push(model), error => this.errorMessage = <any>error);
    //    console.log(this.Content);


}

