import { Component } from '@angular/core';
import { PostService } from './posts/post.service';
import { RouterModule, Routes } from '@angular/router';

@Component({
  selector: 'hb-app',
  template: `
    <div>
        <div class='container'>
            <router-outlet></router-outlet>
        </div>
     </div>


  `,
  providers: [PostService]
})
export class AppComponent {
}
