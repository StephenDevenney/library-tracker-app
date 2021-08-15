import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class PageService {

    constructor(private globals: Globals,
                private http: HttpClient){}

    public async getThemes(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "security/themes").toPromise();
    }

    public async saveSettings(): Promise<void> {
        await this.http.put(this.globals.config.appApiUrl + "security/save-settings", JSON.stringify(this.globals.settings)).toPromise();
        return;
    }

    public async getNavMenu(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "security/navMenu").toPromise();
    }
}