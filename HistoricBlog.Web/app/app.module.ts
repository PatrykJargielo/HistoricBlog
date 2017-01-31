import { NgModule, NgZone } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { PostListComponent } from './posts/post-list.component';
import { createStore, applyMiddleware, compose,Store } from 'redux';
import { post } from '../redux/reducers/post-reducer';
import { PostActions } from '../redux/actions/post-actions';
import { PostFilterPipe } from './posts/post-filter.pipe';
import { PostService } from './posts/post.service';
import { PostEditor } from './posts/post-editor.component';
import { Ng2PaginationModule } from 'ng2-pagination';
import { CKEditorModule } from 'ng2-ckeditor';
import thunk from 'redux-thunk';
import * as createLogger from 'redux-logger';



const logger = createLogger();

const composeEnhancers = window['__REDUX_DEVTOOLS_EXTENSION_COMPOSE__'] || compose;
export const AppStore = createStore(post, composeEnhancers(applyMiddleware(thunk,logger)));


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        CKEditorModule
        Ng2PaginationModule

    ],
    declarations: [
        AppComponent,
        PostListComponent,
        PostFilterPipe,
        PostEditor
    ],
    providers: [
        PostActions,
	    PostService
    ],
    bootstrap: [AppComponent, PostListComponent]
})
export class AppModule { }


