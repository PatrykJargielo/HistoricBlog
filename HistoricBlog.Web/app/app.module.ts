import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { PostListComponent } from './posts/posts-list.component';

import { createStore, applyMiddleware, compose,Store } from 'redux';
import { rootReducer } from '../redux/reducers/rootReducer';
import { PostActions } from '../redux/actions/post-actions';
import { PostService } from './posts/post-service';
import { PostsState } from '../redux/post-state'

import thunk from 'redux-thunk';
import * as createLogger from 'redux-logger';



const logger = createLogger();

const composeEnhancers = window['__REDUX_DEVTOOLS_EXTENSION_COMPOSE__'] || compose;
export const AppStore: Store<PostsState> = createStore(rootReducer, new PostsState(), composeEnhancers(applyMiddleware(thunk,logger)));


@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        JsonpModule,
        FormsModule
    ],
  declarations: [
      AppComponent,
      PostListComponent
  ],
  providers: [
      PostActions,
      PostService
  ],
  bootstrap: [AppComponent, PostListComponent ]
})
export class AppModule { }


