import { ADD_POST, EDIT_POST, GET_POSTS } from '../actions/post-actions'
import { IPost } from '../actions/post-interface'
import { PostsState } from '../post-state'
import * as clone from 'clone';


export default function posts(state = new PostsState(), action) {
    switch (action.type) {
        case ADD_POST:
            return state;
        case EDIT_POST:
            return state;
        case GET_POSTS:
            //let clone = Object.assign(new PostsState(), state);

            let d = clone();

            //clone.posts = action.posts;
            return clone;
            
        default:
            return state;
    }
}



