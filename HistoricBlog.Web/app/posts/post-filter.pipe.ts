import { PipeTransform, Pipe } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';

@Pipe({
    name: 'postFilter'
})
export class PostFilterPipe implements PipeTransform {

  transform(value: IPost[], filterBy: string): IPost[] {
        filterBy = filterBy ? filterBy.toLocaleLowerCase() : null;
        return filterBy ? value.filter((post: IPost) =>
            post.title.toLocaleLowerCase().indexOf(filterBy) !== -1) : value;
    }
}
