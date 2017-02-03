import {IPost} from './actions/post-interface'

export class PostsState {
    userName: string;
    token: string;
    filterTitle: string;
    filterCategory: string[];
    filterTag: string[];
    posts: IPost[];
    pagination: {
        pageNumber: number,
        totalFilteredPostCount: number,
        postsOnPage: number
    } 
    errors: string[];
}