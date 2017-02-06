import { Component, NgZone, OnInit, OnDestroy } from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { Subscription } from 'rxjs/Subscription';
import { PostActions } from '../../redux/actions/post-actions';
import { IPost } from '../../redux/actions/post-interface'

import { HBlogState } from '../../redux/hblog-state';
import { AppStore } from '../app.module';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule } from '@angular/forms';


@Component({
    templateUrl: 'app/posts/editPost.component.html',


})
export class EditPost implements OnInit/*, OnDestroy*/ {
    model: IPost;
    editPostForm: FormGroup;
    postTemp;
    stateModel: HBlogState;
    private sub: Subscription;
    
    constructor(private postService: PostService,
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private _postActions: PostActions,
        private _router: Router,
        private zone: NgZone) {
        //this.model = new IPost();
        this.stateModel = AppStore.getState() as HBlogState;
        
        
    }

    updatePost() {
        //this.postTemp = this.postForm.value;
        //this.model.categories = this.postTemp.categories.split(',');
        //this.model.tags = this.postTemp.tags.split(',');
        //this.model = this.editPostForm.value;
        //this.model.shortDescription = this.postTemp.ShortDescription;
        //this.model.title = this.postTemp.Title;

        
        this.postService.updatePost(this.model);
        console.log(this.model);
    }

    ngOnInit(): void {
        //AppStore.subscribe(() => { this.postListnener() });
        //this.sub = this.route.params.subscribe(
        //    params => {
        //        let id = + params['id'];
        //        AppStore.dispatch(this.getPost(id));
        //    });
        this.stateModel = AppStore.getState() as HBlogState;

        if (this.stateModel.posts.length == 0) {
            this.model =
                {id: 0 , title: "", shortDescription: "", categories: [], tags: [], content: "" };
        } else {
            this.model = this.stateModel.posts[0]

        }
        console.log(this.model)
        this.buildForm();

    }
    //postListnener(): void {
    //    this.stateModel = AppStore.getState() as PostsState;
    //    this.model = this.stateModel.posts[0]

    //    this.zone.run(() => {
    //        this.model = this.stateModel.posts[0]
    //    });
    //}

    //ngOnDestroy() {
    //    this.sub.unsubscribe();
    //}

    //getPost(id: number) {
    //    let idFromRoute = + this.route.snapshot.params['id'];

    //    return (dispatch) => {
    //        this.postService.getPost(idFromRoute).then(
    //            post => dispatch(this._postActions.getPost(post.json())
    //            )
    //        );
    //    }
    //}

    buildForm(): void {
        console.log(this.model);

        
        this.editPostForm = this.fb.group({
            'Content': [this.model.content],
            'Title': [
                this.model.title, [
                    Validators.required,
                    Validators.minLength(10),
                    Validators.maxLength(50)
                ]
            ],
            'ShortDescription': [
                this.model.shortDescription, [
                    Validators.required,
                    Validators.minLength(10),
                    Validators.maxLength(500)
                ]
            ]
            
        });
        console.log(this.editPostForm)
        this.editPostForm.valueChanges.subscribe(data => this.onValueChanged(data));

        this.onValueChanged();
    }


    onValueChanged(data?: any) {
        if (!this.editPostForm) {
            return;
        }
        const form = this.editPostForm;

        for (const field in this.formErrors) {
            this.formErrors[field] = '';
            const control = form.get(field);

            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + ' ';
                }
            }
        }
    }


    formErrors = {
        'Title': '',
        'ShortDescription': '',
        'categories': '',
        'tags': ''

    };

    validationMessages = {
        'Title': {
            'required': 'Tytuł jest wymagany',
            'minlength': 'Tytuł musi sie składać z co najmniej 10 znaków',
            'maxlength': 'Tytuł może mieć maksymalnie 50 znaków.'
        },
        'ShortDescription': {
            'required': 'Krótki opis jest wymagany',
            'minlength': 'Krótki opis musi sie składać z co najmniej 10 znaków',
            'maxlength': 'Krótki opis może mieć maksymalnie 500 znaków.'
        },
        'categories': {
            'required': 'Kategoria jest wymagany',
            'minlength': 'Kategoria musi sie składać z co najmniej 3 znaków',
            'maxlength': 'Kategoria może mieć maksymalnie 20 znaków.'
        },
        'tags': {
            'required': 'Tag jest wymagany',
            'minlength': 'Tag musi sie składać z co najmniej 3 znaków',
            'maxlength': 'Tag może mieć maksymalnie 20 znaków.'
        }
    };


}


