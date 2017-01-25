export interface IPost {
    id: number;
    title: string;
    shortDescription: string;
    content: string;
    categories: string;
    tags: string;
}

export class Post implements IPost {
    constructor(
        public id: number,
        public title: string,
        public shortDescription: string,
        public content: string,
        public categories: string,
        public tags: string) {
    }
}
