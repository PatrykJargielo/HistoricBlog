import { Component, OnInit, Inject, NgZone } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { AppStore } from '../app.module';
import { HBlogState as PostsState } from '../../redux/hblog-state';
import { FormsModule } from '@angular/forms';
import { AsyncDataWrapper } from '../../redux/actions/generic-post';


@Component({

    templateUrl: 'app/posts/post-list.component.html',
    styleUrls: ['app/posts/post-list.component.css']
})

export class PostListComponent implements OnInit {
    stateModel: PostsState;
    listFilter: string;
    posts: IPost[];

    constructor(private _postActions: PostActions, private zone: NgZone) {
        this.stateModel = AppStore.getState() as PostsState;
        this.listFilter = '';
    }
    ngOnInit(): void {
        AppStore.subscribe(() => {
            this.postListener();
        });
        this._postActions.getPostsFilteredPage();

    }

    postListener() {
        this.stateModel = AppStore.getState() as PostsState;
        this.zone.run(() => {
            this.posts = this.stateModel.posts.data;
        });
    }

    setTitleFilter(value) {
        AppStore.dispatch((dispatch) => {
            dispatch(this._postActions.setPostTitleFilter(value));
        });
        this._postActions.getPostsFilteredPage();
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

    pageChanged(value): void {
        AppStore.dispatch(
            (dispatch) => { dispatch(this._postActions.setPostListPage(value)) }
        )
        this._postActions.getPostsFilteredPage();
    }
}