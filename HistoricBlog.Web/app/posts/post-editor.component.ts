﻿import { Component, NgZone, OnInit, OnDestroy, Inject } from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { Post } from './postEditor';
import { IPost } from '../../redux/actions/post-interface'
import { HBlogState } from '../../redux/hblog-state';
import { AppStore } from '../app.module';
import { PostActions } from '../../redux/actions/post-actions';
import { Subscription } from 'rxjs/Subscription';
import { Router, ActivatedRoute  } from '@angular/router';
import { HBlogState as PostsState } from '../../redux/hblog-state';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';


@Component({
    templateUrl: 'app/posts/post-editor.component.html'
})

export class PostEditor implements OnInit, OnDestroy {
    model: IPost;
    postForm: FormGroup;
    tagAndCategorySplit;
    stateModel: HBlogState;
    private sub: Subscription;
    post;
  
    constructor(private postService: PostService,
        @Inject(FormBuilder)private fb: FormBuilder,
        private route: ActivatedRoute,
        private _postActions: PostActions,
        private _router: Router,
        private zone: NgZone,
        private _postService: PostService) {
        this.stateModel = AppStore.getState() as PostsState;

    }

    addPost() {
        this.post = this.postForm.value;
        this.model.Content = this.post.Content;
        this.model.Title = this.post.Title;
        this.model.ShortDescription = this.post.ShortDescription;
        this._postActions.addPost(this.model);

    }
    deletePost() {
            this.post = this.postForm.value;
        this.model.Content = this.post.Content;
        this.model.Title = this.post.Title;
        this.model.ShortDescription = this.post.ShortDescription;
        this._postActions.addPost(this.model);

    }
    ngOnInit(): void {
        AppStore.subscribe(() => { this.postListener() });
        
        this.sub = this.route.params.subscribe(
            params => {
                let id = + params['id'];
                //this.model = this.stateModel.post;
                console.log(id, "idCheck");
                if (typeof params['id'] === 'undefined') {
                    this.model = { Id: 0, Title: "", ShortDescription: "", Categories: [], Tags: [], Content: "" };

                    console.log(this.model, "Test");
                } else {
                    let idFromRoute = + this.route.snapshot.params['id'];
                    this._postActions.getPost(idFromRoute);
                    this.model = this.stateModel.post.data;

                    console.log(this.model, "Test2");
                }

        this.buildForm();
            });
        //TODO dispatch na getPost     
        console.log(this.model, 'model');

    }

    postListener() {
        this.stateModel = AppStore.getState() as PostsState;

        this.zone.run(() => {
            this.model = this.stateModel.post.data;
            console.log(this.model, 'dd2');

        });
    }
    //getPost(id: number) {

    //    let idFromRoute = + this.route.snapshot.params['id'];

    //    this._postActions.getPost(idFromRoute);
    //    console.log(this._postActions.getPost(idFromRoute), 'actionrIdRoute');

    //}

    buildForm(): void {

        this.postForm = this.fb.group({
            'Content': this.fb.group,
            'Title': [
                this.fb.group, [
                    Validators.required,
                    Validators.minLength(10),
                    Validators.maxLength(50)
                ]
            ],
            'ShortDescription': [
                this.fb.group, [
                    Validators.required,
                    Validators.minLength(10),
                    Validators.maxLength(500)
                ]
            ]
        });

        this.postForm.valueChanges.subscribe(data => this.onValueChanged(data));

        this.onValueChanged();

    }


    onValueChanged(data?: any) {
        if (!this.postForm) {
            return;
        }
        const form = this.postForm;

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
        'ShortDescription': ''
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
        }
    };
    onBack(): void {
            this._router.navigate(['']);
        }
    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}