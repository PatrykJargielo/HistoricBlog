import { Inject } from '@angular/core';
import { IPost } from './post-interface'
import { PostService } from '../../app/posts/post.service';
import { AppStore } from '../../app/app.module';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/toPromise';
import 'rxjs/Rx';

import * as PostActions from './post-actions'

import { Http, Response, HttpModule, RequestOptions, Headers, URLSearchParams } from '@angular/http';



export const STATUS_SUCCEEDED = "STATUS_SUCCEEDED";
export const STATUS_STARTED = "STATUS_STARTED";
export const STATUS_FAILED = "STATUS_FAILED";



export class AsyncDataWrapper<T> {
    status;
    promise;
    data: T;
    error;
    
  
    
    


}