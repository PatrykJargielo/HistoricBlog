import { Component, NgZone, OnInit, OnDestroy } from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { Post } from './postEditor';
import { IPost } from '../../redux/actions/post-interface'
import { PostsState } from '../../redux/post-state';
import { AppStore } from '../app.module';
import { PostActions } from '../../redux/actions/post-actions';
import { Subscription } from 'rxjs/Subscription';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { FormGroup, FormBuilder, Validators, FormsModule} from '@angular/forms';

@Component({
    selector: 'editor',
    templateUrl: 'app/posts/post-editor.component.html'


})
export class PostEditor implements OnInit, OnDestroy {
    model: IPost;
    postForm: FormGroup;
    tagAndCategorySplit;
    stateModel: PostsState;
    private sub: Subscription;

    constructor(private postService: PostService,
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private _postActions: PostActions,
        private _router: Router,
        private zone: NgZone) {
        this.stateModel = AppStore.getState() as PostsState;
    }

    addPost() {
        //this.tagAndCategorySplit = this.postForm.value;
        //this.model.Categories = this.tagAndCategorySplit.categories.split(',');
        //this.model.Tags = this.tagAndCategorySplit.tags.split(',');
        //this.model.Content = this.tagAndCategorySplit.Content;
        //this.model.ShortDescription = this.tagAndCategorySplit.ShortDescription;
        //this.model.Title = this.tagAndCategorySplit.Title;
       
        console.log(this.model);   
        this.postService.addPost(this.model);   
        console.log(this.model);
    }

    ngOnInit(): void {
        console.log(this.model)
        this.buildForm(); 
    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }


    buildForm(): void {
        this.postForm = this.fb.group({
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
    

