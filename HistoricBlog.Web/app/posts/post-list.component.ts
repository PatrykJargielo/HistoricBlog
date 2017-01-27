import { Component, OnInit, Inject } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post.service';
import { AppStore } from '../app.module';

@Component({
    selector: 'hb-posts-list',
    templateUrl: 'app/posts/post-list.component.html',
    styleUrls: ['app/posts/post-list.component.css']
})

export class PostListComponent implements OnInit {
    private _postService: PostService;
    listFilter: string;
    posts: IPost[]=[];

    constructor( @Inject(PostService) postService: PostService, private _postActions: PostActions) {
        this._postService = postService;
    }

    ngOnInit(): void {
        // this._postService.getProducts()
        //     .subscribe(x => this.posts = x);
        // console.log(this.posts);
        // AppStore.dispatch(this._postActions.getAllPosts(this.posts));
        // console.log(AppStore.getState());
    }
}