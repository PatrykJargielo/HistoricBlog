import {IPost} from './actions/post-interface'

export class PostsState {
    pageCurrent: number
    filterTitle: string
    filterCategory: string[]
    filterTag: string[]
    posts: IPost[]
    pagination: {
        pageNumber: number,
        pagesTotal: number,
        postsOnPage: number
    } 
}