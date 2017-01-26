import { IPost } from './post-interface'

export const ADD_POST = "ADD_POST";
export const EDIT_POST = "EDIT_POST";
export const GET_POSTS = "GET_POSTS";



export class PostActions {

    //addPost(post: IPost[]) {
    //    return {type: ADD_POST, post }
    //}

    getAllPosts(post: IPost[]) {
        return { type: GET_POSTS, posts:post }
    }

    //editPost(post: IPost[]) {
    //    return { type: EDIT_POST, post }
    //}


    
}
