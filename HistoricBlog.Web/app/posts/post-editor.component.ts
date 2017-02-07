import { Component, NgZone, OnInit, OnDestroy} from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { Post } from './postEditor';
import { IPost } from '../../redux/actions/post-interface'
import { HBlogState } from '../../redux/hblog-state';
import { AppStore } from '../app.module';
import { PostActions } from '../../redux/actions/post-actions';
import { Subscription } from 'rxjs/Subscription';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { HBlogState as PostsState } from '../../redux/hblog-state';
import { FormGroup, FormBuilder, Validators, FormsModule} from '@angular/forms';

@Component({
    templateUrl: 'app/posts/post-editor.component.html'


})
export class PostEditor implements OnInit {
    model: IPost;
    id: number;
    postForm: FormGroup;
    tagAndCategorySplit;
    stateModel: HBlogState;
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

        this.model = this.postForm.value;
        console.log(this.model);   
        this._postActions.addPost(this.model).then(function() {
            //TODO po dodaniu posta
        }).catch(function(parameters) {
            //TODO po nieudanym  dodaniu
        })
        
       
    }

    //ngOnInit(): void {
    //    AppStore.subscribe(() => {
    //        this.postListener();
    //    });
                

    //    if (this.stateModel.posts.length == 0) {
            
    //        this.model =
    //            { id: 0, title: "", shortDescription: "", categories: [], tags: [], content: "" };
    //    } else {
    //        this.model = this.stateModel.posts[0];
    //    }

    //    this.buildForm();


    //}

    //postListener() {
    //    this.stateModel = AppStore.getState() as PostsState;
  
    //    this.zone.run(() => {

    //        this.model = this.stateModel.posts[0];
    //    });
    //}

    ngOnInit(): void {
        AppStore.subscribe(() => {
            this.postListener();
        });
        this.model = { id: 0, title: "", shortDescription: "", categories: [], tags: [], content: "" };
        this.buildForm();
        

    }

    postListener() {
        this.stateModel = AppStore.getState() as PostsState;
        
        this.zone.run(() => {
            //AppStore.dispatch(this._postActions.getPost(this.id));
            this.model= this.stateModel.post.data;
        });
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


}
    

