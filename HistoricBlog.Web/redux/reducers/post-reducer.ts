import { ADD_POST, EDIT_POST, GET_POSTS } from '../actions/post-actions'
import { IPost } from '../actions/post-interface'

const initialState = {
    posts: new Array<IPost>()
}


export default function posts(state = initialState, action:any) {
    switch (action.type) {
        case ADD_POST:
            return state;
        case EDIT_POST:
            return state;
        case GET_POSTS:
            return {
                posts: state.posts.concat(action.posts)
            }

        default:
            return state;
    }
}



