import { Injectable } from '@angular/core';

@Injectable()
export class Book {
    public title: Titles = new Titles;
    public authors: Array<string> = new Array<string>();
    public isbn: string = "";
    public description: string = "";
    public pageCount: number = 0;
    public imageLinks: ImageLinks = new ImageLinks;
}

@Injectable()
export class Titles {
    public bookName: string = "";
    public bookSubTitle: string = "";
}

@Injectable()
export class ImageLinks {
    public small: string = "";
    public standard: string = "";
}
