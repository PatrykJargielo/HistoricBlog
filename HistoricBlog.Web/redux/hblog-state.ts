import { IPost } from './actions/post-interface'
import { AsyncDataWrapper } from './actions/generic-post';

export class HBlogState {
    userName: string;
    token: string;
    filterTitle: string;
    filterCategory: string[];
    filterTag: string[];
    posts;
    post;
    pagination: {
        pageNumber: number;
        totalFilteredPostCount: number;
        postsOnPage: number;
    }
    errors: string[];

    constructor() {
        this.filterTitle = '';
        this.posts = new AsyncDataWrapper<IPost[]>();
        this.post = new AsyncDataWrapper<IPost>();
        this.posts.data = [];
        this.pagination = {
            pageNumber: 1,
            totalFilteredPostCount: 2,
            postsOnPage: 5
        }
        this.errors = [];
    }
}