﻿import { Component, OnInit, Inject, NgZone } from '@angular/core';
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
    _postService: PostService;
    listFilter: string;
    posts: IPost[]=[];



    constructor( @Inject(PostService) postService: PostService, private _postActions: PostActions, private zone: NgZone) {
        this._postService = postService;
        let defaultState = AppStore.getState() as PostsState
        this.listFilter = defaultState.filterTitle;
    }

    getAllPosts() {
        return (dispatch) => {
            this._postService.getPosts().then(
                posts => dispatch(this._postActions.getAllPosts(JSON.parse(posts._body)))
            )
        }
    }

    setPostsTitleFilter(title:string) {
        return (dispatch) => {
            dispatch(this._postActions.setPostTitleFilter(title))
               }
    }

    updateFilter(value) {
        AppStore.dispatch(this.setPostsTitleFilter(value));
        AppStore.dispatch(this.getAllPosts());
    }



    postListener() {
        //TODO filter
        let state = AppStore.getState() as PostsState

        this.zone.run(() => {
            this.posts = state.posts;         
        });
    }




    ngOnInit(): void {
        AppStore.subscribe(() => {
            this.postListener()
        });
        AppStore.dispatch(this.getAllPosts());
    }
}