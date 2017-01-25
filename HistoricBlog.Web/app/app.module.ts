import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { PostListComponent } from './posts/posts-list.component';

import { createStore } from 'redux';
import { rootReducer } from '../redux/reducers/rootReducer';
import { PostActions } from '../redux/actions/post-actions';
import { PostService } from './posts/post-service';
import 'redux-devtools-extension';

export const AppStore = createStore(rootReducer);


@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        JsonpModule,
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


