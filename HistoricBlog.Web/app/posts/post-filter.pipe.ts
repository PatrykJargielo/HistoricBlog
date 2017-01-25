import { PipeTransform, Pipe } from '@angular/core';
import { IPost } from '../../redux/actions/post-interface';

@Pipe({
    name: 'postFilter'
})

export class PostFilterPipe implements PipeTransform {
    transform(value: IPost[], args: string): IPost[] {
        let filter: string = args ? args.toLocaleLowerCase() : null;

        return filter ? value.filter((product: IPost) =>
            product.title.toLocaleLowerCase().indexOf(filter) !== -1) : value;
    }
}
