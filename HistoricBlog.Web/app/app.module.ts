import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { PostListComponent } from './posts/post-list.component';
import { createStore } from 'redux';
import { rootReducer } from '../redux/reducers/rootReducer';
import { PostActions } from '../redux/actions/post-actions';
import { PostFilterPipe } from './posts/post-filter.pipe';
import { PostService } from './posts/post.service';
import 'redux-devtools-extension';

export const AppStore = createStore(rootReducer);


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule
    ],
    declarations: [
        AppComponent,
        PostListComponent,
        PostFilterPipe
    ],
    providers: [
        PostActions, PostService
    ],
    bootstrap: [AppComponent, PostListComponent]
})
export class AppModule { }


