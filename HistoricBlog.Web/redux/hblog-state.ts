import {IPost} from './actions/post-interface'

export class HBlogState {
    userName: string;
    token: string;
    filterTitle: string;
    filterCategory: string[];
    filterTag: string[];
    posts: IPost[];
    pagination: {
        pageNumber: number;
        totalFilteredPostCount: number;
        postsOnPage: number;
    } 
    errors: string[];

    constructor() {
        this.userName = 'guest';
        this.token = '';
        this.filterCategory = [];
        this.filterTitle = '';
        this.filterTag = [];
        this.posts = [];
        this.pagination = {
            pageNumber: 1,
            totalFilteredPostCount: 2,
            postsOnPage: 5
        }
        this.errors = [];
    }
}