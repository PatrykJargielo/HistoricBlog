import { Component, OnInit, Inject } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';
import { PostActions } from '../../redux/actions/post-actions';
import { PostService } from './post.service';
import { AppStore } from '../app.module';

@Component({
    selector: 'hb-post-list',
    templateUrl: 'app/posts/post.details.component.html',
    styleUrls: ['app/posts/post-list.component.css']
})

export class PostDetailsComponent
    {};
