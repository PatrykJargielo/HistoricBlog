import { combineReducers } from 'redux';
import post from './post-reducer';

export let rootReducer = <any>combineReducers({
    post
})

export default rootReducer;