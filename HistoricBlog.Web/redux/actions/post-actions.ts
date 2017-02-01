import { IPost } from './post-interface'

export const ADD_POST = "ADD_POST";
export const EDIT_POST = "EDIT_POST";
export const GET_POSTS = "GET_POSTS";
export const SET_POSTS_CATEGORY_FILTER = "SET_POSTS_DESCRIPTION_FILTER";
export const SET_POSTS_TAG_FILTER = "SET_POSTS_TAG_FILTER";
export const SET_POSTS_TITLE_FILTER = "SET_POSTS_TITLE_FILTER";
export const SET_POSTS_LIST_PAGE = "SET_POSTS_LIST_PAGE";
export const SET_ERRORS = "SET_ERRORS";



export class PostActions {

    addPost(post: IPost) {
        return { type: ADD_POST, payload:post }
    }

    getAllPosts(post) {
        return { type: GET_POSTS, payload:post }
    }

    editPost(post: IPost) {
        return { type: EDIT_POST, payload: post }
    }

    setPostCategoryFilter(categories: string[]) {
        return { type: SET_POSTS_CATEGORY_FILTER, filterCategory:categories }
    }

    setPostTagFilter(tags: string[]) {
        return { type: SET_POSTS_TAG_FILTER, filterTag:tags }
    }

    setPostTitleFilter(title: string) {
        return { type: SET_POSTS_TITLE_FILTER, filterTitle:title }
    }

    setPostListPage(pageNumber:number) {
        return { type: SET_POSTS_LIST_PAGE, pageNumber: pageNumber }
    }

    setErrors(errors: string[]) {
        return { type: SET_ERRORS, payload: errors }
    }

}
