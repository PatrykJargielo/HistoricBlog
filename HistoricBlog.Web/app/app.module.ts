import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { PostListComponent } from './posts/posts-list.component';
import { createStore } from 'redux';
import { rootReducer } from '../redux/reducers/rootReducer';
import { PostActions } from '../redux/actions/post-actions';
import { PostService } from './posts/post-service';
import { PostFilterPipe } from './posts/post-filter.pipe';
import 'redux-devtools-extension';


export const AppStore = createStore(rootReducer);


@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        JsonpModule,
        FormsModule
    ],
    declarations: [
        AppComponent,
        PostListComponent,
        PostFilterPipe
    ],
    providers: [
        PostActions,
        PostService
    ],
    bootstrap: [AppComponent, PostListComponent]
})
export class AppModule { }


