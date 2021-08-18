import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from 'src/app/shared/classes/book';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class HomeService {

    constructor(private globals: Globals,
                private http: HttpClient){}

    public async searchForBook(isbn: string): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "book/book-isbn/" + isbn).toPromise();
    }

    public async addBookToCollection(bookVM: Book): Promise<any> {
        return await this.http.post(this.globals.config.appApiUrl + "book/add", JSON.stringify(bookVM)).toPromise();
    }
}