import { Component, OnInit} from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post-service';
import { AppStore } from '../app.module';


@Component({
    selector: 'hb-posts-list',
    moduleId: module.id,
    templateUrl: 'post-list.component.html',
    styleUrls: ['post-list.component.css']
})

export class PostListComponent implements OnInit {
    posts: IPost[];

    constructor(private _productService: PostService, private _postActions: PostActions) {
        //let state = AppStore.getState();
        
        
    };

    ngOnInit(): void {
        AppStore.subscribe(() => console.log(AppStore.getState()));
        

        this._productService.getProducts()
            .subscribe(x => this.posts = x);

        AppStore.dispatch(this._postActions.getAllPosts(this.posts))
    }


}