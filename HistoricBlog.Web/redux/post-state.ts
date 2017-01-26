import {IPost} from './actions/post-interface'

export class PostsState {
    posts: any

    constructor() {
        this.posts = [];
    }
}