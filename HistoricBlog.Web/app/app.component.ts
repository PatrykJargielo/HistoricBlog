import { Component } from '@angular/core';
import { PostService } from './posts/post.service';

@Component({
  selector: 'hb-app',
  template: `
  <div>
     <hb-error-display></hb-error-display>
     <editor></editor> 
     <hb-posts-list></hb-posts-list>
  </div>
  `,
  providers: [PostService]
})
export class AppComponent {
}
