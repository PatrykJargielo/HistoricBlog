import { combineReducers } from 'redux';
import posts from './post-reducer';

export let rootReducer = <any>combineReducers({
    posts
})

export default rootReducer;