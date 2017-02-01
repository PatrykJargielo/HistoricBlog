import { Component, OnInit, Inject, OnDestroy } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post.service';
import { AppStore } from '../app.module';
import { Subscription } from 'rxjs/Subscription';
import { Router, ActivatedRoute, Params } from '@angular/router';


@Component({
    templateUrl: 'app/posts/post-details.component.html'
})

export class PostDetailsComponent implements OnInit, OnDestroy {
    pageTitle: string = 'Post Detail';
    post: IPost;
    errorMessage: string;
    private sub: Subscription;

    constructor(private _route: ActivatedRoute,
        private _router: Router,
        private _postService: PostService,
        private route: ActivatedRoute ) {
    }

    ngOnInit(): void {
        this.sub = this._route.params.subscribe(
            params => {
                let id = + params['id'];
                this.getPost(id);
            });
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }

    getPost(id: number) {
        // this._postService.getPost(id).subscribe(
        //     product => this.post = id,
        //     error => this.errorMessage = <any>error);
        this.route.params
            .switchMap((params: Params) => this._postService.getPost(+params['id']))
            .subscribe(post => this.post = post);
    }

    onBack(): void {
        this._router.navigate(['']);
    }

    onRatingClicked(message: string): void {
        this.pageTitle = 'Post Detail: ' + message;
    }
};
