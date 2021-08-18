import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from 'src/app/shared/classes/book';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class BooksService {

    constructor(private globals: Globals,
                private http: HttpClient){}

    public async getBookCollection(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "book/collection").toPromise();
    }
}