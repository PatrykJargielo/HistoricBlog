import {Category} from "./Category";

export class Post {
    public Id?: string;
    public Title: string;
    public ShortDescription: string;
    public Content: string;
    public Categories: string[];
    public Tags: string[];
    constructor(
    ) { }
}