import { NgModule, NgZone } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { PostListComponent } from './posts/post-list.component';
import { PostDetailsComponent } from './posts/post-details.component';
import { PostDetailGuard } from './posts/post-guard.service';
import { ErrorDisplayComponent } from './shared/error-display.component';
import { createStore, applyMiddleware, compose, Store } from 'redux';
import { post } from '../redux/reducers/post-reducer';
import { PostActions } from '../redux/actions/post-actions';
import { AsyncDataWrapper } from '../redux/actions/generic-post';
import { PostService } from './posts/post.service';
import { CategoryService } from './posts/category.service';
import { PostEditor } from './posts/post-editor.component';
import { Ng2PaginationModule } from 'ng2-pagination';
import { CKEditorModule } from 'ng2-ckeditor';
import thunk from 'redux-thunk';
import * as createLogger from 'redux-logger';
import { NavbarComponent } from './navbar/navbar.component';
import { ContactComponent } from './shared/contact.component';

const logger = createLogger();

const composeEnhancers = window['__REDUX_DEVTOOLS_EXTENSION_COMPOSE__'] || compose;
export const AppStore = createStore(post, composeEnhancers(applyMiddleware(thunk, logger)));


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        JsonpModule,
        CKEditorModule,
        Ng2PaginationModule,       
        RouterModule.forRoot([
            { path: '', component: PostListComponent },
            {
                path: 'post/:id',
                canActivate: [PostDetailGuard],
                component: PostDetailsComponent
            },
            {
                path: 'addPost',
                component: PostEditor
            },
                        {
                path: 'contact',
                component: ContactComponent
            },
            {
                path: 'editPost/:id',
                component: PostEditor
            },
            { path: 'posts', redirectTo: '', pathMatch: 'full' },
            { path: '**', redirectTo: '', pathMatch: 'full' }
        ])
    ],
    declarations: [
        AppComponent,
        PostListComponent,
        ErrorDisplayComponent,
        PostEditor,
        PostDetailsComponent,
        NavbarComponent,
        ContactComponent
    ],
    providers: [
        PostActions,
        PostService,
        CategoryService,
        PostDetailGuard,
        AsyncDataWrapper,
    ],
    bootstrap: [AppComponent],
    exports: [PostEditor]
})
export class AppModule { }


