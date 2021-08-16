import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class PageService {

    constructor(private globals: Globals,
                private http: HttpClient){}

    public async getThemes(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "enum/themes").toPromise();
    }

    public async getNavMenu(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "security/nav-menu").toPromise();
    }
}