import { ADD_POST, EDIT_POST, GET_POSTS, SET_POSTS_TITLE_FILTER } from '../actions/post-actions'
import { IPost } from '../actions/post-interface'
//import { PostsState } from '../post-state'
import * as clone from 'clone';

let defaultState = {
    
    pageCurrent: 1,
    filterCategory: [],
    filterTitle: '',
    filterTag: [],
    posts: [],
    pagination: {
        pageNumber: 1,
        pagesTotal: 1,
        postsOnPage: 10,
    } 

}

export function post(state = defaultState, action) {

    switch (action.type) {
        case ADD_POST:
            return state;
        case EDIT_POST:
            return state;
        case GET_POSTS:
            return Object.assign({}, state, {
                page:0,
                posts:action.post
            })
        case SET_POSTS_TITLE_FILTER:
            let newState = Object.assign({}, state)
            newState.filterTitle = action.filterTitle;
            return newState;
        default:
            return state;
    }
}

export default post;




