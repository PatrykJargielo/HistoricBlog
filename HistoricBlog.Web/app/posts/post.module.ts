import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';

import { PostListComponent } from './post-list.component';
import { PostDetailsComponent } from './post-details.component';
import { PostDetailGuard } from './post-guard.service';

import { PostFilterPipe } from './post-filter.pipe';
import { PostService } from './post.service';


@NgModule({
  imports: [
        RouterModule.forChild([
      { path: 'products', component: PostListComponent },
      { path: 'product/:id',
        canActivate: [ PostDetailGuard],
        component: PostDetailsComponent
      }
    ])
  ],
  declarations: [
    PostListComponent,
    PostDetailsComponent,
    PostFilterPipe
  ],
  providers: [
    PostService,
    PostDetailGuard
  ]
})
export class ProductModule {}
