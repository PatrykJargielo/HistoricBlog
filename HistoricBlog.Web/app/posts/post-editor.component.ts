﻿import { Component, OnInit} from '@angular/core';
import { CKEditorModule } from 'ng2-ckeditor';
import { PostService } from './post.service';
import { CategoryService } from './category.service';
import { Post } from './postEditor';
import { Category } from './Category';
import { FormGroup, FormBuilder, Validators, FormsModule} from '@angular/forms';

@Component({
    selector: 'editor',
    templateUrl: 'app/posts/post-editor.component.html',


})
export class PostEditor implements OnInit {
    model: Post;
    tags: string;
    categories: string;
    postForm: FormGroup;
    tagAndCategorySplit;

    constructor(private postService: PostService, private fb: FormBuilder) {
        
    }

    addPost() {
        this.tagAndCategorySplit = this.postForm.value;
        this.model.Categories = this.tagAndCategorySplit.categories.split(',');
        this.model.Tags = this.tagAndCategorySplit.tags.split(',');
        this.model.Content = this.tagAndCategorySplit.Content;
        this.model.ShortDescription = this.tagAndCategorySplit.ShortDescription;
        this.model.Title = this.tagAndCategorySplit.Title;
       
        console.log(this.model);   
        this.postService.addPost(this.model);   
        console.log(this.model);
    }

    ngOnInit(): void {
        this.model = new Post();
        this.buildForm();
    }


    buildForm(): void {
        this.postForm = this.fb.group({
            'Content': [this.model.Content],
            'Title': [
                this.model.Title, [
                    Validators.required,
                    Validators.minLength(10),
                    Validators.maxLength(50)
                ]
            ],
            'ShortDescription': [
                this.model.ShortDescription, [
                    Validators.required,
                    Validators.minLength(10),
                    Validators.maxLength(500)
                ]
            ],
            'categories': [
                this.categories, [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(20)
                ]
            ],
            'tags': [
                this.tags, [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(20)
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
    

