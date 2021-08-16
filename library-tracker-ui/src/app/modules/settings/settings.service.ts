import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class SettingsService {

    constructor(private globals: Globals,
                private http: HttpClient){}

    public async getAppIdleSecs(): Promise<any> {
        return await this.http.get(this.globals.config.appApiUrl + "enum/appIdleSecs").toPromise();
    }
}