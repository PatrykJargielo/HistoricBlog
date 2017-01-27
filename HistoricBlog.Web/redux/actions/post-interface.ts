export interface IPost {
    Title: string,
    ShortDescription: string,
    Content: string,
    Categories: string[],
    Tags: string[]
    Comments: string[]
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
