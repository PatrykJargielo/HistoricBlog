import { ADD_POST, EDIT_POST, GET_POSTS } from '../actions/post-actions'
import { IPost } from '../actions/post-interface'
import { PostsState } from '../post-state'
import * as clone from 'clone';

let defaultState = new PostsState();

export default function posts(state = defaultState, action) {
    switch (action.type) {
        case ADD_POST:
            return state;
        case EDIT_POST:
            return state;
        case GET_POSTS:
            let newState = Object.assign(new PostsState(), state);
            newState.posts = action.posts;
            return newState.posts;   
        default:
            return state;
    }
}



