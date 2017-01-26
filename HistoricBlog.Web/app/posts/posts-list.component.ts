import { Component, OnInit, Inject} from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post-service';
import { AppStore } from '../app.module';


@Component({
    selector: 'hb-posts-list',
    templateUrl: 'app/posts/post-list.component.html',
    styleUrls: ['app/posts/post-list.component.css']
})




export class PostListComponent implements OnInit {
    posts: IPost[];
    _postService: PostService; 

    constructor( @Inject(PostService) postService: PostService, private _postActions: PostActions) {
        this._postService = postService;
    }

    getAllPosts() {
        return (dispatch) => {
            this._postService.getPosts().then(
                posts => dispatch(this._postActions.getAllPosts(JSON.parse(posts._body)))
            )
        }
    }

    postListener() {
        let state = AppStore.getState();
        this.posts = state.posts
    }

    

    ngOnInit(): void {

        AppStore.subscribe(this.postListener);
        AppStore.dispatch(this.getAllPosts())
        console.log(AppStore.getState());


    }


}