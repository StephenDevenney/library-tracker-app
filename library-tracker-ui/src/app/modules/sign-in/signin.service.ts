import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Globals } from 'src/app/shared/classes/globals';

@Injectable()
export class SignInService {

    constructor(private globals: Globals,
                private http: HttpClient){}

    public async authenticate(userName: string): Promise<any> {
        return await this.http.get(this.globals.config.authApiUrl + "auth/authenticate/" + userName).toPromise();
    }
}