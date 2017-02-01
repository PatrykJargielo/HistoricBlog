import {
    ADD_POST,
    EDIT_POST,
    GET_POSTS,
    SET_POSTS_TITLE_FILTER,
    SET_POSTS_LIST_PAGE,
    SET_ERRORS
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
    },
    errors: []

}

export function post(state = defaultState, action) {

    let newState = state;
    switch (action.type) {
        case SET_POSTS_LIST_PAGE:
            newState = Object.assign({}, state);
            newState.pagination.pageNumber = action.pageNumber;
            newState.errors = [];
            return newState;
        case ADD_POST:
            newState = Object.assign({}, state);
            newState.posts.concat(action.payload.post);
            newState.errors = [];
            return state;
        case EDIT_POST:
            newState = Object.assign({}, state);
            newState.posts.filter((post) => post.Id != action.post.Id);
            newState.posts.concat(action.payload.post);
            newState.errors = [];
            return state;
        case GET_POSTS:
            newState = Object.assign({}, state);
            newState.pagination.totalFilteredPostCount = action.payload.totalFilteredPostCount;
            newState.posts = action.payload.posts;
            newState.errors = [];
            return newState;  
        case SET_POSTS_TITLE_FILTER:
            newState = Object.assign({}, state);
            newState.filterTitle = action.filterTitle;
            newState.errors = [];
            return newState;
        case SET_ERRORS:;
            newState = Object.assign({}, state);
            newState.errors = action.payload;
            return newState;
        default:
            return newState;
    }
}

export default post;



