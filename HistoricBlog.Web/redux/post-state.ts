import {IPost} from './actions/post-interface'
import {Post} from '../app/posts/postEditor';

export class PostsState {
    userName: string;
    token: string;
    filterTitle: string;
    filterCategory: string[];
    filterTag: string[];
    posts: IPost[];
    updatePost: Post;
    pagination: {
        pageNumber: number,
        totalFilteredPostCount: number,
        postsOnPage: number
    } 
    errors: string[];
}