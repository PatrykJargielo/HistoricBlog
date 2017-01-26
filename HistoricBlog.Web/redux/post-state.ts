import {IPost} from './actions/post-interface'

export class PostsState {
    posts: IPost[];

    constructor() {
        this.posts = [];
    }
}