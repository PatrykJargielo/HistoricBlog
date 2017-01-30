import { NgModule, NgZone } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { PostListComponent } from './posts/post-list.component';
import { PostDetailsComponent } from './posts/post-details.component';
import { PostDetailGuard } from './posts/post-guard.service';
import { createStore, applyMiddleware, compose, Store } from 'redux';
import { post } from '../redux/reducers/post-reducer';
import { PostActions } from '../redux/actions/post-actions';
import { PostFilterPipe } from './posts/post-filter.pipe';
import { PostService } from './posts/post.service';
import thunk from 'redux-thunk';
import * as createLogger from 'redux-logger';



const logger = createLogger();

const composeEnhancers = window['__REDUX_DEVTOOLS_EXTENSION_COMPOSE__'] || compose;
export const AppStore = createStore(post, composeEnhancers(applyMiddleware(thunk, logger)));


@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        RouterModule.forRoot([
            { path: '', component: PostListComponent },
            { path: 'posts', redirectTo: '', pathMatch: 'full' },
            { path: '**', redirectTo: '', pathMatch: 'full' },

        ]),
        RouterModule.forChild([{
            path: 'post/:id',
            canActivate: [PostDetailGuard],
            component: PostDetailsComponent
        }])
    ],
    declarations: [
        AppComponent,
        PostListComponent,
        PostFilterPipe,
        PostDetailsComponent
    ],
    providers: [
        PostActions,
        PostService,
        PostDetailGuard
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }


