import {
    ADD_POST,
    EDIT_POST,
    GET_POSTS,
    GET_POST,
    SET_POSTS_TITLE_FILTER,
    SET_POSTS_LIST_PAGE,
    SET_ERRORS,
    ADD_POST_SUCCESS,
    ADD_POST_ERROR,
    ADD_POST_REQUEST

} from '../actions/post-actions'
import {
    STATUS_SUCCEEDED,
    STATUS_STARTED,
    STATUS_FAILED

} from '../actions/generic-post';
import { IPost } from '../actions/post-interface'
import { HBlogState } from '../hblog-state'


//let defaultState = {
//    userName: 'guest',
//    token: '',
//    filterCategory: [],
//    filterTitle: '',
//    filterTag: [],
//    posts: [],
//    pagination: {
//        pageNumber: 1,
//        totalFilteredPostCount: 2,
//        postsOnPage: 5,
//    },
//    errors: []

//}

let defaultState = new HBlogState();

export function post(state = defaultState, action) {

    let newState = state;
    switch (action.type) {
        case SET_POSTS_LIST_PAGE:
            newState = Object.assign({}, state);
            newState.pagination.pageNumber = action.pageNumber;
            newState.errors = [];
            return newState;               
        case ADD_POST_REQUEST:
            newState = Object.assign({}, state);
            newState.post.promise = action.payload;
            newState.post.status = STATUS_STARTED;
            return newState;
        case ADD_POST_SUCCESS:
            newState = Object.assign({}, state);
            newState.post.data = action.payload.post;
            //newState.posts.status = STATUS_SUCCEEDED;
            return newState;
        case ADD_POST_ERROR:
            newState = Object.assign({}, state);
            newState.post.status = STATUS_FAILED;
            newState.post.errors.error = [];
            return newState;
        case EDIT_POST:
            newState = Object.assign({}, state);
            newState.posts.filter((post) => post.id != action.post.Id);
            newState.posts.concat(action.payload.post);
            newState.errors = [];
            return state;
        case GET_POSTS:
            newState = Object.assign({}, state);
            newState.pagination.totalFilteredPostCount = action.payload.totalFilteredPostCount;
            newState.posts.data = action.payload.posts;
            newState.errors = [];
            return newState;
        case SET_POSTS_TITLE_FILTER:
            newState = Object.assign({}, state);
            newState.filterTitle = action.filterTitle;
            newState.errors = [];
            return newState;
        case SET_ERRORS: ;
            newState = Object.assign({}, state);
            newState.posts.status = STATUS_FAILED;
            newState.errors = action.payload;
            return newState;
        case GET_POST:
            newState = Object.assign({}, state);
            newState.post.data = action.payload;
            return newState;
        default:
            return newState;
    }
}

export default post;







