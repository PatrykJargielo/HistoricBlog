import { ADD_POST, EDIT_POST, GET_POSTS } from '../actions/post-actions'
import { IPost } from '../actions/post-interface'
//import { PostsState } from '../post-state'
import * as clone from 'clone';

let defaultState = {
    page:1,
    posts:[]
}

export function post(state = defaultState, action) {


    switch (action.type) {
        case ADD_POST:
            return state;
        case EDIT_POST:
            return state;
        case GET_POSTS:
            return Object.assign({}, state, {
                page:10,
                posts:action.post
            })
        default:
            return state;
    }
}

export default post;




