import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post.service';
import { AppStore } from '../app.module';
import { PostsState } from '../../redux/post-state';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'hb-posts-list',
        templateUrl: 'app/posts/post-list.component.html',
            styleUrls: ['app/posts/post-list.component.css']
})

export class PostListComponent implements OnInit {
    stateModel: PostsState;
    listFilter: string;
    posts: IPost[]=[];

    constructor( private postService: PostService, private _postActions: PostActions, private zone: NgZone) {
        this.postService = postService;
        this.stateModel = AppStore.getState() as PostsState;
        this.listFilter = '';
    }

    ngOnInit(): void {
        AppStore.subscribe(() => {
            this.postListener()
        });
        AppStore.dispatch(this.getAllPosts());
        
    }

    postListener() {
        this.stateModel = AppStore.getState() as PostsState;
        this.zone.run(() => {
            this.posts = this.stateModel.posts;
        });
    }

    getAllPosts() {
        return (dispatch) => {
            this.postService.getPostsFilteredPage(this.stateModel.pagination.pageNumber, this.stateModel.pagination.postsOnPage, this.stateModel.filterTitle).then(
                posts => dispatch(this._postActions.getAllPosts(posts.json()),
                )
            )
        }
    }

    setTitleFilter(value) {
        AppStore.dispatch((dispatch) => {
            dispatch(this._postActions.setPostTitleFilter(value))
        });
        AppStore.dispatch(this.getAllPosts());
    }

    getPostCount(): number {
        return this.stateModel.pagination.totalFilteredPostCount;
    }

    getPostsOnPageCount(): number {
        return this.stateModel.pagination.postsOnPage;
    }

    getCurrentPageNumber(): number {
        return this.stateModel.pagination.pageNumber;
    }

    pageChanged(value): void{
        AppStore.dispatch(
            (dispatch) => { dispatch(this._postActions.setPostListPage(value)) }        
        )
       AppStore.dispatch(this.getAllPosts());
    }
}