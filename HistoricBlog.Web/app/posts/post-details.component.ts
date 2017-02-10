import { Component,NgZone ,OnInit, Inject, OnDestroy } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post.service';
import { AppStore } from '../app.module';
import { Subscription } from 'rxjs/Subscription';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HBlogState as PostsState } from '../../redux/hblog-state';
import { AsyncDataWrapper } from '../../redux/actions/generic-post';


@Component({
    templateUrl: 'app/posts/post-details.component.html'
})

export class PostDetailsComponent implements OnInit, OnDestroy {
    pageTitle: string = 'Post Detail';
    post: IPost;
    stateModel: PostsState;
    errorMessage: string;
    private sub: Subscription;

    constructor(private _route: ActivatedRoute,
        private _router: Router,
        private _postService: PostService,
        private route: ActivatedRoute,
        private _postActions: PostActions,
        private zone:NgZone)
    {
        this.stateModel = AppStore.getState() as PostsState;
    }

    ngOnInit(): void {
        AppStore.subscribe(() => {this.postListnener()});
        this.sub = this._route.params.subscribe(
            params => {
                let id = + params['id'];
                AppStore.dispatch(this.getPost(id));
            });
    }

    postListnener(): void {
        this.stateModel = AppStore.getState() as PostsState;
        this.post = this.stateModel.post.data;

        this.zone.run(() => {
            this.post = this.stateModel.post.data;
        });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    getPost(id: number) {
        //// this._postService.getPost(id).subscribe(
        ////     post => this.post = id,
        ////     error => this.errorMessage = <any>error);
        let idFromRoute =+ this.route.snapshot.params['id'];
        //this._postService.getPost(idFromRoute);
        //    .subscribe(post => this.post = post/*);*/

        return (dispatch) => {
            this._postService.getPost(idFromRoute).then(
                post => dispatch(this._postActions.getPost(post.json())
                )
            );
        }
    }

    onBack(): void {
            this._router.navigate(['']);
        }
        onRatingClicked(message: string): void {
            this.pageTitle = 'Post Detail: ' + message;
        }
    };
