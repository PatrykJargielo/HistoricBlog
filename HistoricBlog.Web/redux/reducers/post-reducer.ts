import {
    ADD_POST,
    EDIT_POST,
    GET_POSTS,
    SET_POSTS_TITLE_FILTER,
    SET_POSTS_LIST_PAGE
} from '../actions/post-actions'

import { IPost } from '../actions/post-interface'


let defaultState = {
    userName: 'guest',
    token: '',
    filterCategory: [],
    filterTitle: '',
    filterTag: [],
    posts: [],
    pagination: {
        pageNumber: 1,
        totalFilteredPostCount: 2,
        postsOnPage: 5,
    } 

}

export function post(state = defaultState, action) {

    let newState = state;
    switch (action.type) {
        case SET_POSTS_LIST_PAGE:
            newState = Object.assign({}, state)
            newState.pagination.pageNumber = action.pageNumber;
            return newState;
        case ADD_POST:
            return state;
        case EDIT_POST:
            return state;
        case GET_POSTS:
            newState = Object.assign({}, state)
            newState.pagination.totalFilteredPostCount = action.payload.totalFilteredPostCount,
            newState.posts = action.payload.posts
            return newState;  
        case SET_POSTS_TITLE_FILTER:
            newState = Object.assign({}, state)
            newState.filterTitle = action.filterTitle;
            return newState;
        default:
            return newState;
    }
}

export default post;



